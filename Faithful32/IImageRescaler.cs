using System.Drawing;

namespace Faithful32 {
	/// <summary>
	/// Describes all classes that can rescale images to 2X size.
	/// </summary>
	interface IImageRescaler {
		// User must dispose of the bitmap
		Bitmap Rescale(Image src);
	}
}
