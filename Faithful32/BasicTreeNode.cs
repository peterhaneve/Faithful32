using System.Collections.Generic;

namespace Faithful32 {
	/// <summary>
	/// A very simple tree node which maintains a list of its child nodes and its (possibly
	/// null) value.
	/// </summary>
	class BasicTreeNode<T> {
		public IEnumerable<BasicTreeNode<T>> Children => children;

		public int ChildCount => children.Count;

		public BasicTreeNode<T> FirstChild => children[0];

		public bool IsLeaf {
			get {
				return children == null || ChildCount == 0;
			}
		}

		public string Key { get; }

		public T Value { get; }

		private IList<BasicTreeNode<T>> children;

		public BasicTreeNode(string key, T value) {
			// null / empty is allowed
			Key = key;
			Value = value;
			children = null;
		}

		public void AddChild(BasicTreeNode<T> child) {
			if (children == null)
				children = new List<BasicTreeNode<T>>(32);
			children.Add(child);
		}

		public override bool Equals(object obj) {
			var other = obj as BasicTreeNode<T>;
			return other != null && other.Key == Key;
		}

		public override int GetHashCode() {
			return Key.GetHashCode();
		}

		public override string ToString() {
			return Key + ": " + (Value == null ? "null" : Value.ToString());
		}
	}
}
