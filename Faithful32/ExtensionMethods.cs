using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Faithful32 {
	/// <summary>
	/// Extension methods make life easier!
	/// </summary>
	static class ExtensionMethods {
		private static readonly object DUMMY_TAG = new object();

		private static TreeNode CreateDummy() {
			var node = new TreeNode("Loading");
			node.Tag = DUMMY_TAG;
			node.SelectedImageIndex = node.ImageIndex = -1;
			return node;
		}

		public static BitmapData GetData(this Bitmap image) {
			var bounds = new Rectangle(Point.Empty, image.Size);
			return image.LockBits(bounds, ImageLockMode.ReadWrite, image.PixelFormat);
		}

		public static bool Matches<T>(this TreeNodeCollection nodes, BasicTreeNode<T> tree) {
			int count = nodes.Count;
			return count == tree.ChildCount && (count != 1 || nodes[0]?.Tag != DUMMY_TAG);
		}

		public static int RoundToInt(this decimal value) {
			return (int)Math.Round(value);
		}

		public static int RoundToInt(this float value) {
			return (int)Math.Round(value);
		}

		public static float RoundToFloat(this decimal value) {
			return (float)Math.Round(value, 3);
		}

		public static decimal RoundToDisplay(this float value) {
			return Math.Round((decimal)value, 3);
		}

		public static int ToRange(this int value, int min, int max) {
			return Math.Min(max, Math.Max(min, value));
		}

		public static float ToRange(this float value, float min, float max) {
			return Math.Min(max, Math.Max(min, value));
		}

		public static TreeNode ToTreeNode(this BasicTreeNode<TextureEntry> node) {
			bool leaf = node.IsLeaf;
			var value = node.Value;
			string text;
			if (leaf)
				text = value.FileName;
			else
				text = string.Format("{0} ({1})", node.Key, node.ChildCount);
			var tNode = new TreeNode(text);
			tNode.Tag = node;
			if (leaf) {
				var dims = value.ImageSize;
				string path = value.FullPath;
				// StateImageIndex works super well but only supports 0-14...
				tNode.ImageKey = tNode.SelectedImageKey = path;
				tNode.ToolTipText = string.Format("{0:D}x{1:D}\r\n{2}", dims.Width, dims.Height, path);
			} else {
				tNode.ImageIndex = tNode.SelectedImageIndex = 0;
				// ensure that it has a plus sign
				tNode.Nodes.Add(CreateDummy());
			}
			return tNode;
		}
	}
}
