using System;
using System.Collections;
using System.Collections.Generic;

namespace StardewConfigFramework.Options {

	public class Selection: ModOption, IList<SelectionChoice>, IDictionary<string, SelectionChoice> {
		public delegate void Handler(Selection selection);
		public event Handler SelectionDidChange;

		private readonly OrderedIdentifierDictionary<SelectionChoice> Choices = new OrderedIdentifierDictionary<SelectionChoice>();

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

		public SelectionChoice this[int index] { get => Choices[index]; set => Choices[index] = value; }
		public SelectionChoice this[string identifier] { get => Choices[identifier]; set => Choices[identifier] = value; }

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

		public void Add(SelectionChoice choice) {
			Choices.Add(choice.Identifier, choice);
		}

		public void Add(string identifier, SelectionChoice choice) {
			Choices.Add(identifier, choice);
		}

		public void Add(KeyValuePair<string, SelectionChoice> choice) {
			Choices.Add(choice.Key, choice.Value);
		}

		public void Clear() {
			Choices.Clear();
		}

		public bool Contains(string identifier) {
			return Choices.Contains(identifier);
		}

		public bool Contains(SelectionChoice choice) {
			return Choices.Contains(choice.Identifier);
		}

		public bool Contains(KeyValuePair<string, SelectionChoice> choice) {
			return Choices.Contains(choice.Key);
		}

		public bool ContainsKey(string identifier) {
			return Choices.Contains(identifier);
		}

		public void CopyTo(SelectionChoice[] array, int arrayIndex) {
			Choices.CopyTo(array, arrayIndex);
		}

		public void CopyTo(KeyValuePair<string, SelectionChoice>[] array, int arrayIndex) {
			Choices.CopyTo(array, arrayIndex);
		}


		/// <summary>
		/// Index of the identifier
		/// </summary>
		/// <returns>The index of of the <paramref name="identifier"/>. Returns -1 if identifier does not exist.</returns>
		/// <param name="identifier">Identifier.</param>
		public int IndexOf(string identifier) {
			return Choices.IndexOf(identifier);
		}

		public int IndexOf(SelectionChoice choice) {
			return IndexOf(choice.Identifier);
		}

		public void Insert(int index, SelectionChoice choice) {
			Choices.Insert(index, choice);
		}

		public bool Remove(SelectionChoice choice) {
			return Choices.Remove(choice);
		}

		public bool Remove(string identifier) {
			return Choices.Remove(identifier);
		}

		public bool Remove(KeyValuePair<string, SelectionChoice> choice) {
			return Remove(choice);
		}

		public void RemoveAt(int index) {
			Choices.RemoveAt(index);
		}

		public bool TryGetValue(string identifier, out SelectionChoice choice) {
			return Choices.TryGetValue(identifier, out choice);
		}

		public IEnumerator<SelectionChoice> GetEnumerator() {
			return Choices.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return Choices.GetEnumerator();
		}

		IEnumerator<KeyValuePair<string, SelectionChoice>> IEnumerable<KeyValuePair<string, SelectionChoice>>.GetEnumerator() {
			return ((IDictionary<string, SelectionChoice>) Choices).GetEnumerator();
		}
	}

	public class SelectionChoice: Tuple<string, string, string>, SCFObject {
		public SelectionChoice(string identifier, string label, string hoverText = null) : base(identifier, label, hoverText) { }
		public string Identifier => Item1;
		public string Label => Item2;
		public string HoverText => Item3;
	}
}
