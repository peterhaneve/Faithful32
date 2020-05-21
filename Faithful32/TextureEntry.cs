using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Faithful32 {
	/// <summary>
	/// A class representing all of the details of a texture sprite in a mod.
	/// </summary>
	sealed class TextureEntry : IDisposable, IComparable<TextureEntry> {
		public const string ASSETS = "assets";
		
		public string FileName {
			get {
				return Path.GetFileName(FullPath);
			}
		}

		public string AnimationData { get; set; }

		public string FullPath { get; }

		public Bitmap ImageData { get; }

		public Size ImageSize { get; }

		public string LastDirectory { get; }

		public ISet<string> PathElements { get; }

		public TextureEntry(string path, Bitmap img) {
			if (string.IsNullOrEmpty(path))
				throw new ArgumentNullException("path");
			if (img == null)
				throw new ArgumentNullException("img");
			FullPath = path;
			ImageData = img;
			ImageSize = img.Size;
			// assets/MODNAME/textures/items/extras/
			LastDirectory = Path.GetPathRoot(FullPath);
			PathElements = new HashSet<string>(TexturePack.SplitPath(path));
		}

		public int CompareTo(TextureEntry other) {
			return FullPath.CompareTo(other.FullPath);
		}

		public override string ToString() {
			return FileName + " (" + ImageSize + ")";
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		void Dispose(bool disposing) {
			if (!disposedValue) {
				if (disposing) {
					ImageData.Dispose();
				}
				disposedValue = true;
			}
		}

		// This code added to correctly implement the disposable pattern.
		public void Dispose() {
			Dispose(true);
		}

		#endregion
	}
}
