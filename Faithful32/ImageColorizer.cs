using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Faithful32 {
	/// <summary>
	/// Performs Brightness/Contrast and Colorize operations on an image.
	/// </summary>
	sealed class ImageColorizer {
		private const float HUE_SECTS = 6.0f;
		private const float HUE_PIE = 1.0f / HUE_SECTS;
		// Maximum value of RGB colors (0-255 inclusive)
		private const float RGB_MAX = 255.0f;
		private const float RGB_DIV = 1.0f / RGB_MAX;
		private const float L_DIV = 0.5f / RGB_MAX;

		private static int FloatToRGB(float value) {
			return Math.Min(255, Math.Max(0, (int)(RGB_MAX * value)));
		}

		private static int HtoRGB(float m1, float m2, float hmod) {
			float axis;
			if (hmod > HUE_SECTS)
				hmod -= HUE_SECTS;
			else if (hmod < 0.0f)
				hmod += HUE_SECTS;
			if (hmod < 1.0f)
				axis = m1 + (m2 - m1) * hmod;
			else if (hmod < 3.0f)
				axis = m2;
			else if (hmod < 4.0f)
				axis = m1 + (m2 - m1) * (4.0f - hmod);
			else
				axis = m1;
			return FloatToRGB(axis);
		}

		public static void HSLtoRGB(float h, float s, float l, out int r, out int g, out int b) {
			// HSL units are 0-1 but RGB are 0-255
			if (s <= 0.0f)
				r = g = b = FloatToRGB(l);
			else {
				float m1, m2;
				if (l < 0.5f)
					m2 = l * (1.0f + s);
				else
					m2 = l + s - l * s;
				m1 = 2.0f * l - m2;
				r = HtoRGB(m1, m2, h * HUE_SECTS + 2.0f);
				g = HtoRGB(m1, m2, h * HUE_SECTS);
				b = HtoRGB(m1, m2, h * HUE_SECTS - 2.0f);
			}
		}

		public static void RGBtoHSL(int r, int g, int b, out float h, out float s, out float l) {
			int max = r, min = r;
			if (g > max) max = g;
			if (g < min) min = g;
			if (b > max) max = b;
			if (b < min) min = b;
			float c = (max - min) * RGB_DIV;
			// HSL units are 0-1
			l = (max + min) * L_DIV;
			if (max == min)
				h = 0.0f;
			else if (max == r) {
				h = HUE_PIE * (g - b) * RGB_DIV / c;
				if (h < 0.0f) h += 1.0f;
			} else if (max == g)
				h = HUE_PIE * (b - r) * RGB_DIV / c + (2.0f * HUE_PIE);
			else
				h = Math.Min(1.0f, HUE_PIE * (r - g) * RGB_DIV / c + (4.0f * HUE_PIE));
			// All white or all black have zero saturation
			if (l >= 1.0f || l <= 0.0f)
				s = 0.0f;
			else if (l <= 0.5f)
				s = c * 0.5f / l;
			else
				s = c * 0.5f / (1.0f - l);
		}

		// User must manage this image's life cycle!
		public Bitmap Result { get; }

		public ImageColorizer(Image src) {
			if (src == null)
				throw new ArgumentNullException("src");
			// Note that the image mode must be transformed to RGB in case the original image
			// was in indexed color
			var size = src.Size;
			Result = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
			using (var g = Graphics.FromImage(Result)) {
				g.DrawImageUnscaled(src, 0, 0);
			}
		}

		public void BrightnessContrast(int bright, int con) {
			bright = bright.ToRange(-127, 127);
			// contrast 127 causes div by 0, gimp divides brightness by 2
			con = con.ToRange(-127, 126);
			BrightnessContrastUnsafe(bright * RGB_DIV, con / 127.0f);
		}

		private unsafe void BrightnessContrastUnsafe(float bright, float con) {
			var data = Result.GetData();
			int stride = data.Stride, width = data.Width, height = data.Height;
			float slant = (float)Math.Tan((con + 1.0) * Math.PI * 0.25);
			try {
				byte* line = (byte*)data.Scan0;
				for (int y = 0; y < height; y++) {
					int* pos = (int*)line;
					for (int x = 0; x < width; x++) {
						// BE format so ARGB
						int c = *pos, b = c & 0xFF, g, r, a, max = b, min = b;
						c >>= 8;
						g = c & 0xFF;
						if (g > max) max = g;
						if (g < min) min = g;
						c >>= 8;
						r = c & 0xFF;
						if (r > max) max = r;
						if (r < min) min = r;
						a = c >> 8;
						float r1 = r * RGB_DIV, g1 = g * RGB_DIV, b1 = b * RGB_DIV;
						if (bright < 0.0f) {
							r1 *= 1.0f + bright;
							g1 *= 1.0f + bright;
							b1 *= 1.0f + bright;
						} else {
							r1 += (1.0f - r1) * bright;
							g1 += (1.0f - g1) * bright;
							b1 += (1.0f - b1) * bright;
						}
						r = FloatToRGB((r1 - 0.5f) * slant + 0.5f);
						g = FloatToRGB((g1 - 0.5f) * slant + 0.5f);
						b = FloatToRGB((b1 - 0.5f) * slant + 0.5f);
						*pos++ = b | (g << 8) | (r << 16) | (a << 24);
					}
					// stride is measured in bytes so int *line would crash
					line += stride;
				}
			} finally {
				Result.UnlockBits(data);
			}
		}

		public void Colorize(float hue, float sat, float light) {
			hue = hue.ToRange(0.0f, 1.0f);
			sat = sat.ToRange(0.0f, 1.0f);
			light = light.ToRange(-1.0f, 1.0f);
			// saturation is 0-1, lightness is -1 to 1
			ColorizeUnsafe(hue, sat, light);
		}

		private unsafe void ColorizeUnsafe(float hue, float sat, float light) {
			var data = Result.GetData();
			int stride = data.Stride, width = data.Width, height = data.Height;
			float l;
			try {
				byte* line = (byte*)data.Scan0;
				for (int y = 0; y < height; y++) {
					int* pos = (int*)line;
					for (int x = 0; x < width; x++) {
						int c = *pos, b = c & 0xFF, g, r, a, max = b, min = b;
						c >>= 8;
						g = c & 0xFF;
						if (g > max) max = g;
						if (g < min) min = g;
						c >>= 8;
						r = c & 0xFF;
						if (r > max) max = r;
						if (r < min) min = r;
						a = c >> 8;
						// why compute h/s when we only need the l?
						l = (max + min) * L_DIV;
						if (light > 0.0f)
							l = l * (1.0f - light) + light;
						else
							l = l * (light + 1.0f);
						HSLtoRGB(hue, sat, l, out r, out g, out b);
						*pos++ = b | (g << 8) | (r << 16) | (a << 24);
					}
					line += stride;
				}
			} finally {
				Result.UnlockBits(data);
			}
		}
	}
}
