using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Faithful32 {
	/// <summary>
	/// Rescales images using nearest neighbor interpolation.
	/// </summary>
	class DefaultImageRescaler : IImageRescaler {
		public const int RESCALE = 2;

		public Bitmap Rescale(Image src) {
			// Note that the image mode must be transformed to RGB in case the original image
			// was in indexed color
			var size = src.Size;
			int nw = size.Width * RESCALE, nh = size.Height * RESCALE;
			var result = new Bitmap(nw, nh, PixelFormat.Format32bppArgb);
			using (var g = Graphics.FromImage(result)) {
				g.InterpolationMode = InterpolationMode.NearestNeighbor;
				g.PixelOffsetMode = PixelOffsetMode.Half;
				g.DrawImage(src, 0, 0, nw, nh);
			}
			return result;
		}
	}
}
