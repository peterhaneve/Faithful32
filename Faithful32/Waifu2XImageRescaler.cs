using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace Faithful32 {
	class Waifu2XImageRescaler : IImageRescaler {
		private readonly string waifuPath;

		public Waifu2XImageRescaler() {
			waifuPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().
				Location), "waifu2x-converter-cpp.exe");
		}

		public Bitmap Rescale(Image src) {
			string tempDir = Path.GetTempPath();
			string tempInput = Path.Combine(tempDir, "waifu2x_input.png"), tempOutput = Path.
				Combine(tempDir, "waifu2x_output.png");
			Bitmap rescaled = null;
			try {
				src.Save(tempInput, ImageFormat.Png);
				var info = new ProcessStartInfo(waifuPath, "-c 4 -p 0 -m scale --scale-ratio 2 -o \"" +
						tempOutput + "\" -i \"" + tempInput + "\"") {
					CreateNoWindow = true,
					WindowStyle = ProcessWindowStyle.Hidden,
					WorkingDirectory = Path.GetDirectoryName(waifuPath)
				};
				using (var proc = Process.Start(info)) {
					// Yes it blocks, yes it sucks
					if (proc.WaitForExit(5000))
						using (var result = Image.FromFile(tempOutput, true)) {
							rescaled = new Bitmap(result);
						}
					else
						proc.Kill();
				}
			} finally {
				// Do not throw in finally
				try {
					File.Delete(tempInput);
					File.Delete(tempOutput);
				} catch { }
			}
			return rescaled;
		}
	}
}
