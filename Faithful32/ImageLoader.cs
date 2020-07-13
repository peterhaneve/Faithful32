using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;

namespace Faithful32 {
	/// <summary>
	/// Loads and saves images to files, or reads them from a mod JAR/ZIP.
	/// </summary>
	static class ImageLoader {
		public const string ANI_EXT = "mcmeta";
		private const string TEXTURES = "textures";
		public const string TEXTURE_EXT = "png";

		public static TexturePack GetModTextures(string path, ZipArchive file) {
			var mod = new TexturePack(path);
			// ani data needs to be held separately
			var aniData = new Dictionary<string, string>();
			foreach (var entry in file.Entries) {
				string name = entry.FullName;
				if (name.StartsWith(TextureEntry.ASSETS) && name.Contains(TEXTURES)) {
					if (name.EndsWith(TEXTURE_EXT)) {
						try {
							using (var stream = entry.Open()) {
								// ignore exception if image data is invalid
								mod.Add(new TextureEntry(name, LoadImageCached(stream)));
							}
						} catch (ArgumentException) { }
					} else if (name.EndsWith("." + ANI_EXT)) {
						string pngName = name.Substring(0, name.Length - 1 - ANI_EXT.Length);
						using (var reader = new StreamReader(entry.Open())) {
							aniData.Add(pngName, reader.ReadToEnd());
						}
					}
				}
			}
			foreach (var texture in mod) {
				string animated;
				if (aniData.TryGetValue(texture.FullPath, out animated))
					texture.AnimationData = animated;
			}
			mod.Sort();
			return mod;
		}

		public static TexturePack GetPackTextures(string path, string[] files) {
			var pack = new TexturePack(path);
			foreach (string imgFile in files)
				if (imgFile.Contains(TEXTURES))
					try {
						// ignore exception if image data is invalid
						var entry = new TextureEntry(imgFile);
						string ani = imgFile + "." + ANI_EXT;
						if (File.Exists(ani))
							entry.AnimationData = File.ReadAllText(ani);
						pack.Add(entry);
					} catch (ArgumentException) { }
			pack.Sort();
			return pack;
		}

		private static Bitmap LoadImageCached(Stream stream) {
			using (Image temp = Image.FromStream(stream)) {
				// Copies the image to a bitmap so original stream can be closed
				return new Bitmap(temp);
			}
		}

		internal static Bitmap LoadFromFile(string path) {
			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read)) {
				// ignore exception if image data is invalid
				return LoadImageCached(stream);
			}
		}
	}
}
