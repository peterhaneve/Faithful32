using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using TextureTree = Faithful32.BasicTreeNode<Faithful32.TextureEntry>;

namespace Faithful32 {
	// TreeView specialization for TexturePack display, including the image
	sealed class PackTreeView : TreeView {
		private static readonly Size NODE_SIZE = new Size(16, 16);
		private static readonly Image BLANK = new Bitmap(NODE_SIZE.Width, NODE_SIZE.Height, PixelFormat.Format32bppArgb);

		public TextureEntry SelectedTexture {
			get {
				return GetEntry(SelectedNode);
			}
		}

		private readonly ImageList images;
		private TextureTree tree;

		public PackTreeView() {
			images = new ImageList();
			images.ImageSize = NODE_SIZE;
			images.ColorDepth = ColorDepth.Depth32Bit;
			images.Images.Add(BLANK);
			tree = null;
			AfterExpand += OnNodeOpen;
			ImageList = images;
			ImageIndex = SelectedImageIndex = 0;
		}

		private void AddImage(TextureTree item) {
			var value = item.Value;
			if (value != null) {
				var path = value.FullPath;
				var imgList = images.Images;
				if (!string.IsNullOrEmpty(path) && !imgList.ContainsKey(path)) {
					value.Load();
					imgList.Add(path, value.ImageData);
				}
			}
		}

		private void DisposeTree() {
			if (tree != null) {
				var imgList = images.Images;
				imgList.Clear();
				imgList.Add(BLANK);
				tree = null;
			}
		}

		private TreeNodeCollection ExpandUpTo(IEnumerable<TextureTree> path) {
			TreeNodeCollection parent = null;
			foreach (var subTree in path) {
				if (parent == null)
					parent = Nodes;
				else {
					// search previous parent for this sub tree
					int count = parent.Count;
					bool found = false;
					for (int i = 0; i < count && !found; i++) {
						var node = parent[i];
						if (node.Tag == subTree) {
							parent = node.Nodes;
							found = true;
						}
					}
					if (!found) {
						parent = null;
						break;
					}
				}
				// expand if needed
				if (!parent.Matches(subTree))
					PopulateNode(subTree, parent);
			}
			return parent;
		}

		public void FindEntry(TextureEntry entry) {
			if (entry != null && tree != null)
				FindPackNode(tree, entry, new LinkedList<TextureTree>());
		}

		private bool FindPackNode(TextureTree root, TextureEntry entry, LinkedList<TextureTree> path) {
			var value = root.Value;
			bool found = false;
			if (value != null && value.PathElements.IsSupersetOf(entry.PathElements)) {
				BeginUpdate();
				try {
					var lastChild = ExpandUpTo(path);
					if (lastChild != null) {
						int count = lastChild.Count;
						for (int i = 0; i < count; i++) {
							var node = lastChild[i];
							if (GetEntry(node) == value) {
								SelectedNode = node;
								node.EnsureVisible();
								break;
							}
						}
					}
				} finally {
					EndUpdate();
				}
				found = true;
			} else if (!root.IsLeaf) {
				path.AddLast(root);
				foreach (var child in root.Children)
					if (FindPackNode(child, entry, path)) {
						found = true;
						break;
					}
				path.RemoveLast();
			}
			return found;
		}

		public TextureEntry GetEntry(TreeNode node) {
			return (node?.Tag as TextureTree)?.Value;
		}

		private void OnNodeOpen(object sender, TreeViewEventArgs e) {
			var node = e.Node;
			var tree = node?.Tag as TextureTree;
			var parent = node?.Nodes;
			if (tree != null && !tree.IsLeaf && !parent.Matches(tree)) {
				// ignore clicks on leaf nodes
				BeginUpdate();
				try {
					PopulateNode(tree, parent);
				} finally {
					EndUpdate();
				}
			}
		}

		private void PopulateNode(TextureTree tree, TreeNodeCollection parent) {
			// expands the node into the child if necessary, wrap in BeginUpdate/EndUpdate
			parent.Clear();
			foreach (var root in tree.Children) {
				AddImage(root);
				parent.Add(root.ToTreeNode());
			}
		}
		
		public void SetPack(TextureTree tree) {
			DisposeTree();
			this.tree = tree;
			BeginUpdate();
			try {
				var nodes = Nodes;
				nodes.Clear();
				if (tree != null && !tree.IsLeaf)
					PopulateNode(tree, nodes);
			} finally {
				EndUpdate();
			}
		}

		#region IDisposable Support
		protected override void Dispose(bool disposing) {
			base.Dispose(disposing);
			if (disposing) {
				DisposeTree();
				images.Dispose();
			}
		}
		#endregion
	}
}
