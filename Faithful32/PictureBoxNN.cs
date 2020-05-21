using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Faithful32 {
	/// <summary>
	/// A picture box which always uses nearest neighbor interpolation.
	/// </summary>
	class PictureBoxNN : PictureBox {
		public Bitmap SourceImage {
			// setting this will overwrite the Image, but Image can also be set separately
			get {
				return sourceImage;
			}
			set {
				SetImage(value);
			}
		}

		private Bitmap sourceImage;

		public PictureBoxNN() : base() {
			sourceImage = null;
		}

		protected override void Dispose(bool disposing) {
			base.Dispose(disposing);
			Image?.Dispose();
		}

		public void DisposeImage() {
			if (sourceImage != null) {
				sourceImage.Dispose();
				sourceImage = null;
			}
			Image?.Dispose();
			Image = null;
		}

		private void SetImage(Bitmap value) {
			sourceImage = value;
			if (value == null) {
				Image?.Dispose();
				Image = null;
			} else {
				var size = value.Size;
				int w = size.Width, h = size.Height, minDim = Math.Min(w, h), maxDim =
					Math.Max(w, h);
				if (w != h && maxDim % minDim == 0 && maxDim > minDim * 2) {
					// display a portion of animation images
					var portionImage = new Bitmap(minDim, minDim, sourceImage.PixelFormat);
					using (var g = Graphics.FromImage(portionImage)) {
						g.DrawImage(sourceImage, 0, 0);
					}
					Image = portionImage;
				} else
					Image = sourceImage;
			}
		}

		protected override void OnPaint(PaintEventArgs paintEventArgs) {
			var g = paintEventArgs.Graphics;
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.PixelOffsetMode = PixelOffsetMode.Half;
			base.OnPaint(paintEventArgs);
		}
	}
}
