using System;
using System.Collections;
using System.Collections.Generic;

namespace StardewConfigFramework.Options {

	public class Selection: ModOption, ISCFOrderedDictionary<ISelectionChoice> {
		public delegate void Handler(Selection selection);
		public event Handler SelectionDidChange;

		private readonly SCFOrderedDictionary<ISelectionChoice> Choices = new SCFOrderedDictionary<ISelectionChoice>();

		public Selection(string identifier, string labelText, IList<ISelectionChoice> choices = null, int defaultSelection = 0, bool enabled = true) : base(identifier, labelText, enabled) {
			if (choices != null) {
				foreach (ISelectionChoice choice in choices) {
					Add(choice.Identifier, choice);
				}
				CheckValidIndex(defaultSelection);
				_SelectedIndex = defaultSelection;
			}
		}

		public Selection(string identifier, string labelText, IList<ISelectionChoice> choices, string defaultSelection, bool enabled = true) : base(identifier, labelText, enabled) {
			if (choices != null) {
				foreach (ISelectionChoice choice in choices) {
					Add(choice.Identifier, choice);
				}
				CheckValidIdentifier(defaultSelection);
				_SelectedIndex = IndexOf(defaultSelection);
			}
		}

		public ISelectionChoice this[int index] { get => Choices[index]; set => Choices[index] = value; }
		public ISelectionChoice this[string identifier] { get => Choices[identifier]; set => Choices[identifier] = value; }

		public int Count => Choices.Count;

		public bool IsReadOnly => false;

		public ICollection<string> Keys => Choices.Keys as ICollection<string>;

		public ICollection<ISelectionChoice> Values => Choices.Values as ICollection<ISelectionChoice>;

		private int _SelectedIndex = 0;
		public int SelectedIndex {
			get => _SelectedIndex;
			set {
				CheckValidIndex(value);

				if (_SelectedIndex == value)
					return;

				_SelectedIndex = value;
				SelectionDidChange?.Invoke(this);
			}
		}

		public ISelectionChoice SelectedChoice => (Choices.Count != 0) ? Choices[SelectedIndex] as ISelectionChoice : null;

		public string SelectedIdentifier {
			get => SelectedChoice?.Identifier;
			set {
				CheckValidIdentifier(value);

				int index = IndexOf(value);
				if (_SelectedIndex == index)
					return;

				_SelectedIndex = index;
				SelectionDidChange?.Invoke(this);
			}
		}

		private void CheckValidIndex(int value) {
			if (Count == 0 && value == 0) {
			} else if (value >= Choices.Count || value < 0) {
				throw new IndexOutOfRangeException("Selection is out of range of Choices");
			}
		}

		private void CheckValidIdentifier(string value) {
			if (!Contains(value))
				throw new KeyNotFoundException("Identifier does not exist in Choices");
		}

		public void Add(ISelectionChoice choice) {
			Choices.Add(choice.Identifier, choice);
		}

		public void Add(string identifier, ISelectionChoice choice) {
			Choices.Add(identifier, choice);
		}

		public void Add(KeyValuePair<string, ISelectionChoice> choice) {
			Choices.Add(choice.Key, choice.Value);
		}

		public void Clear() {
			Choices.Clear();
		}

		public bool Contains(string identifier) {
			return Choices.Contains(identifier);
		}

		public bool Contains(ISelectionChoice choice) {
			return Choices.Contains(choice.Identifier);
		}

		public bool Contains(KeyValuePair<string, ISelectionChoice> choice) {
			return Choices.Contains(choice.Key);
		}

		public bool ContainsKey(string identifier) {
			return Choices.Contains(identifier);
		}

		public void CopyTo(ISelectionChoice[] array, int arrayIndex) {
			Choices.CopyTo(array, arrayIndex);
		}

		public void CopyTo(KeyValuePair<string, ISelectionChoice>[] array, int arrayIndex) {
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

		public int IndexOf(ISelectionChoice choice) {
			return IndexOf(choice.Identifier);
		}

		public void Insert(int index, ISelectionChoice choice) {
			Choices.Insert(index, choice);
		}

		public bool Remove(ISelectionChoice choice) {
			return Choices.Remove(choice);
		}

		public bool Remove(string identifier) {
			return Choices.Remove(identifier);
		}

		public bool Remove(KeyValuePair<string, ISelectionChoice> choice) {
			return Remove(choice);
		}

		public void RemoveAt(int index) {
			Choices.RemoveAt(index);
		}

		public bool TryGetValue(string identifier, out ISelectionChoice choice) {
			return Choices.TryGetValue(identifier, out choice);
		}

		public IEnumerator<ISelectionChoice> GetEnumerator() {
			return Choices.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return Choices.GetEnumerator();
		}

		IEnumerator<KeyValuePair<string, ISelectionChoice>> IEnumerable<KeyValuePair<string, ISelectionChoice>>.GetEnumerator() {
			return ((IDictionary<string, ISelectionChoice>) Choices).GetEnumerator();
		}
	}

	public interface ISelectionChoice: SCFObject {
		string HoverText { get; }
	}

	public class SelectionChoice: Tuple<string, string, string>, ISelectionChoice {
		public SelectionChoice(string identifier, string label, string hoverText = null) : base(identifier, label, hoverText) { }
		public string Identifier => Item1;
		public string Label => Item2;
		public string HoverText => Item3;
	}
}
