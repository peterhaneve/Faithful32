using System;
using System.Collections.Generic;
using System.IO;

namespace Faithful32 {
	/// <summary>
	/// Wraps the list of mod/pack textures along with the original directory.
	/// </summary>
	sealed class TexturePack : List<TextureEntry>, IDisposable {
		private static readonly char[] SEPARATORS = new char[] {
			Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar
		};

		public static string[] SplitPath(string path) {
			return path.Split(SEPARATORS);
		}

		public string RootDirectory { get; }

		public TexturePack(string root) {
			if (string.IsNullOrEmpty(root))
				throw new ArgumentNullException("root");
			RootDirectory = root;
		}

		public BasicTreeNode<TextureEntry> AsTree() {
			var root = new BasicTreeNode<TextureEntry>(string.Empty, null);
			foreach (var entry in this) {
				BasicTreeNode<TextureEntry> node = root, next;
				string[] folders = SplitPath(entry.FullPath);
				int last = folders.Length - 1;
				for (int i = 0; i <= last; i++) {
					string folder = folders[i];
					// Value if the node were to be put into this level
					var thisValue = (i == last) ? entry : null;
					next = null;
					if (!node.IsLeaf)
						// Search for node
						foreach (var childNode in node.Children)
							if (childNode.Key == folder) {
								next = childNode;
								break;
							}
					if (next == null)
						// Add new node
						node.AddChild(next = new BasicTreeNode<TextureEntry>(folder,
							thisValue));
					else if (i == last)
						throw new ArgumentException("Duplicate file names in pack / mod!");
					node = next;
				}
			}
			while (!root.IsLeaf && root.ChildCount == 1)
				// 0 child count is not equal to 1
				root = root.FirstChild;
			return root;
		}

		public string FindPathToImage(string relPath) {
			return Path.GetFullPath(Path.Combine(RootDirectory, relPath ?? string.Empty));
		}

		public override string ToString() {
			return string.Format("\"{0}\": {1:D} textures", RootDirectory, Count);
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		void Dispose(bool disposing) {
			if (!disposedValue) {
				if (disposing) {
					foreach (var image in this)
						image.Dispose();
				}
				Clear();
				disposedValue = true;
			}
		}

		// This code added to correctly implement the disposable pattern.
		public void Dispose() {
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
		}
		#endregion
	}
}
