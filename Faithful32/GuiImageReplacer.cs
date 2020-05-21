using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using R = Faithful32.Properties.Resources;

namespace Faithful32 {
	/// <summary>
	/// Rescales GUI images (or other images) up 2:1 nearest neighbor, and optionally replaces
	/// common GUI elements like inventory slots and borders with 32x replacements.
	/// </summary>
	class GuiImageReplacer {
		public Bitmap Result { get; }

		public GuiImageReplacer(Bitmap src) {
			if (src == null)
				throw new ArgumentNullException("src");
			Result = src;
		}

		public void GuiReplace() {
			var data = Result.GetData();
			try {
				ReplaceSubImageUnsafe(data, R.corner_bl, R.new_corner_bl);
				ReplaceSubImageUnsafe(data, R.corner_br, R.new_corner_br);
				ReplaceSubImageUnsafe(data, R.corner_tl, R.new_corner_tl);
				ReplaceSubImageUnsafe(data, R.corner_tr, R.new_corner_tr);
				ReplaceSubImageUnsafe(data, R.side_l, R.new_side_l);
				ReplaceSubImageUnsafe(data, R.side_t, R.new_side_t);
				ReplaceSubImageUnsafe(data, R.side_r, R.new_side_r);
				ReplaceSubImageUnsafe(data, R.side_b, R.new_side_b);
				ReplaceSubImageUnsafe(data, R.inventory_large, R.new_inventory_large);
				ReplaceSubImageUnsafe(data, R.inventory_small, R.new_inventory_small);
				ReplaceSubImageUnsafe(data, R.enderio_bottom, R.new_enderio_bottom);
				ReplaceSubImageUnsafe(data, R.fire_off, R.new_fire_off);
				ReplaceSubImageUnsafe(data, R.fire_on, R.new_fire_on);
			} finally {
				Result.UnlockBits(data);
			}
		}

		private unsafe bool MatchImageAtUnsafe(byte* start, int stride, BitmapData target) {
			byte* dest = (byte*)target.Scan0;
			int height = target.Height, width = target.Width, tStride = target.Stride;
			for (int y = 0; y < height; y++) {
				int* srcRGB = (int*)start, destRGB = (int*)dest;
				for (int x = 0; x < width; x++) {
					int destPixel = *destRGB++;
					// ignore fully transparent pixels in target image
					if ((destPixel >> 24) != 0 && *srcRGB != destPixel)
						return false;
					srcRGB++;
				}
				start += stride;
				dest += tStride;
			}
			return true;
		}
		
		private unsafe void ReplaceImageAtUnsafe(byte* start, int stride, BitmapData newImage) {
			byte* dest = (byte*)newImage.Scan0;
			int height = newImage.Height, width = newImage.Width, tStride = newImage.Stride;
			for (int y = 0; y < height; y++) {
				int* srcRGB = (int*)start, destRGB = (int*)dest;
				for (int x = 0; x < width; x++)
					*srcRGB++ = *destRGB++;
				start += stride;
				dest += tStride;
			}
		}

		private unsafe void ReplaceSubImageUnsafe(BitmapData data, Bitmap needle, Bitmap replacement) {
			int srcWidth = needle.Width, srcHeight = needle.Height, width = data.Width - srcWidth,
				height = data.Height - srcHeight, stride = data.Stride;
			if (replacement.Width != srcWidth || replacement.Height != srcHeight)
				throw new ArgumentException(string.Format("{0} size does not match source {1}",
					replacement, needle));
			var target = Result.PixelFormat;
			if (needle.PixelFormat != target || replacement.PixelFormat != target)
				throw new ArgumentException(string.Format("{0} or {1} format does not match {2}",
					replacement, needle, target));
			BitmapData srcData = needle.GetData(), destData = replacement.GetData();
			try {
				byte* line = (byte*)data.Scan0;
				for (int y = 0; y < height; y++) {
					int* pos = (int*)line;
					for (int x = 0; x < width; x++) {
						byte* start = (byte*)(pos++);
						if (MatchImageAtUnsafe(start, stride, srcData))
							ReplaceImageAtUnsafe(start, stride, destData);
					}
					line += stride;
				}
			} finally {
				needle.UnlockBits(srcData);
				replacement.UnlockBits(destData);
			}
		}


		private struct ColorPaletteItem : IComparable<ColorPaletteItem> {
			public readonly int Frequency;
			public readonly int ColorARGB;

			public ColorPaletteItem(int argb, int frequency) {
				ColorARGB = argb;
				Frequency = frequency;
			}

			public int CompareTo(ColorPaletteItem other) {
				// highest first
				return other.Frequency - Frequency;
			}
		}
	}
}
