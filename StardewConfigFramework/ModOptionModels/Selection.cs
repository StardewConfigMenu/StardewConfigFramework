using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace StardewConfigFramework.Options {

	public class Selection: ModOption, IList<SelectionChoice>, IDictionary<string, SelectionChoice> {
		public delegate void Handler(Selection selection);
		public event Handler SelectionDidChange;

		private readonly OrderedDictionary Choices = new OrderedDictionary();

		public Selection(string identifier, string labelText, IList<SelectionChoice> choices = null, int defaultSelection = 0, bool enabled = true) : base(identifier, labelText, enabled) {
			if (choices != null) {
				foreach (SelectionChoice choice in choices) {
					Add(choice.Identifier, choice);
				}
				SelectedIndex = defaultSelection;
			}
		}

		public Selection(string identifier, string labelText, IList<SelectionChoice> choices, string defaultSelection, bool enabled = true) : base(identifier, labelText, enabled) {
			if (choices != null) {
				foreach (SelectionChoice choice in choices) {
					Add(choice.Identifier, choice);
				}
				SelectedIdentifier = defaultSelection;
			}
		}

		public SelectionChoice this[int index] { get => (SelectionChoice) Choices[index]; set => Choices[index] = value; }
		public SelectionChoice this[string identifier] { get => (SelectionChoice) Choices[identifier]; set => Choices[identifier] = value; }

		public int Count => Choices.Count;

		public bool IsReadOnly => false;

		public ICollection<string> Keys => Choices.Keys as ICollection<string>;

		public ICollection<SelectionChoice> Values => Choices.Values as ICollection<SelectionChoice>;

		private int _SelectedIndex = 0;
		public int SelectedIndex {
			get => _SelectedIndex;
			set {
				if (Choices.Count == 0 && value == 0) {
				} else if (value >= Choices.Count || value < 0) {
					throw new IndexOutOfRangeException("Selection is out of range of Choices");
				}

				if (_SelectedIndex == value)
					return;

				_SelectedIndex = value;
				SelectionDidChange?.Invoke(this);
			}
		}

		public SelectionChoice SelectedChoice => Choices[SelectedIndex] as SelectionChoice;

		public string SelectedIdentifier {
			get => SelectedChoice.Identifier;
			set {
				if (!Choices.Contains(value))
					throw new KeyNotFoundException("Identifier does not exist in Choices");

				int index = IndexOf(value);
				if (_SelectedIndex == index)
					return;

				_SelectedIndex = index;
				SelectionDidChange?.Invoke(this);
			}
		}

		public void Add(SelectionChoice item) {
			Choices.Add(item.Identifier, item);
		}

		public void Add(string identifier, SelectionChoice value) {
			Choices.Add(identifier, value);
		}

		public void Add(KeyValuePair<string, SelectionChoice> item) {
			Choices.Add(item.Key, item.Value);
		}

		public void Clear() {
			Choices.Clear();
		}

		public bool Contains(string identifier) {
			return Choices.Contains(identifier);
		}

		public bool Contains(SelectionChoice item) {
			return Choices.Contains(item.Identifier);
		}

		public bool Contains(KeyValuePair<string, SelectionChoice> item) {
			return Choices.Contains(item.Key);
		}

		public bool ContainsKey(string identifier) {
			return Choices.Contains(identifier);
		}

		public void CopyTo(SelectionChoice[] array, int arrayIndex) {
			int j = 0;
			for (int i = arrayIndex; i < Choices.Count + arrayIndex; i++) {
				array[i] = (SelectionChoice) Choices[j];
				j++;
			}
		}

		public void CopyTo(KeyValuePair<string, SelectionChoice>[] array, int arrayIndex) {
			Choices.CopyTo(array, arrayIndex);
		}

		public IEnumerator<SelectionChoice> GetEnumerator() {
			return Choices.GetEnumerator() as IEnumerator<SelectionChoice>;
		}

		/// <summary>
		/// Index of the identifier
		/// </summary>
		/// <returns>The index of of the <paramref name="identifier"/>. Returns -1 if identifier does not exist.</returns>
		/// <param name="identifier">Identifier.</param>
		public int IndexOf(string identifier) {
			for (int i = 0; i < Choices.Count; i++) {
				if (Choices[i] == Choices[identifier])
					return i;
			}
			return -1;
		}

		public int IndexOf(SelectionChoice item) {
			return IndexOf(item.Identifier);
		}

		public void Insert(int index, SelectionChoice item) {
			Choices.Insert(index, item.Identifier, item);
		}

		public bool Remove(SelectionChoice item) {
			throw new NotImplementedException();
		}

		public bool Remove(string identifier) {
			if (!Contains(identifier))
				return false;

			Choices.Remove(identifier);
			return true;
		}

		public bool Remove(KeyValuePair<string, SelectionChoice> item) {
			return Remove(item.Key);
		}

		public void RemoveAt(int index) {
			Choices.RemoveAt(index);
		}

		public bool TryGetValue(string identifier, out SelectionChoice value) {
			if (!Contains(identifier)) {
				value = default(SelectionChoice);
				return false;
			}

			value = this[identifier];
			return true;
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return Choices.GetEnumerator();
		}

		IEnumerator<KeyValuePair<string, SelectionChoice>> IEnumerable<KeyValuePair<string, SelectionChoice>>.GetEnumerator() {
			return Choices.GetEnumerator() as IEnumerator<KeyValuePair<string, SelectionChoice>>;
		}
	}

	public class SelectionChoice: Tuple<string, string, string>, SCFObject {
		public SelectionChoice(string identifier, string label, string hoverText = null) : base(identifier, label, hoverText) { }
		public string Identifier => Item1;
		public string Label => Item2;
		public string HoverText => Item3;
	}
}
