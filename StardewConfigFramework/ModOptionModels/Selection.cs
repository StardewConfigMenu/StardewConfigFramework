using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace StardewConfigFramework.Options {
	public class Selection: ModOption {
		public delegate void Handler(string componentIdentifier, string selectionIdentifier);
		public event Handler ValueDidChange;

		internal SelectionChoices _Choices { get; private set; } = new SelectionChoices();

		/// <summary>
		/// Returns a Read Only copy of the choices collection
		/// </summary>
		/// <value>The choices.</value>
		public IReadOnlyCollection<SelectionChoice> Choices => _Choices.AsList();

		public Selection(string identifier, string labelText, IReadOnlyCollection<SelectionChoice> choices = null, int defaultSelection = 0, bool enabled = true) : base(identifier, labelText, enabled) {
			if (choices != null) {
				_Choices = new SelectionChoices(choices);
				SelectionIndex = defaultSelection;
			}
		}

		public Selection(string identifier, string labelText, IReadOnlyCollection<SelectionChoice> choices, string defaultSelection, bool enabled = true) : base(identifier, labelText, enabled) {
			if (choices != null) {
				_Choices = new SelectionChoices(choices);
				if (choices.Count > 0)
					SelectedIdentifier = defaultSelection;
			}
		}

		private int _SelectedIndex = 0;
		public int SelectionIndex {
			get => _SelectedIndex;
			set {
				if (Choices.Count == 0 && value == 0) {
				} else if (value >= Choices.Count || value < 0) {
					throw new IndexOutOfRangeException("Selection is out of range of Choices");
				}

				if (_SelectedIndex == value)
					return;

				_SelectedIndex = value;
				ValueDidChange?.Invoke(Identifier, SelectedIdentifier);
			}
		}

		public string SelectedIdentifier {
			get => _Choices[_SelectedIndex].Identifier;
			set {
				if (!_Choices.Contains(value))
					throw new KeyNotFoundException("Identifier does not exist in Choices");

				int index = _Choices.IndexOf(value);
				if (_SelectedIndex == index)
					return;

				_SelectedIndex = index;
				ValueDidChange?.Invoke(Identifier, SelectedIdentifier);
			}
		}

		/// <summary>
		/// Gets the <see cref="T:StardewConfigFramework.Options.SelectionChoices"/> at the specified index.
		/// </summary>
		/// <param name="index">Index.</param>
		public SelectionChoice this[int index] => _Choices[index];

		/// <summary>
		/// Gets the <see cref="T:StardewConfigFramework.Options.SelectionChoices"/> with the specified identifier.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		public SelectionChoice this[string identifier] => _Choices[identifier];

		public void Insert(int index, SelectionChoice choice) {
			_Choices.Insert(index, choice);
		}

		public void Add(SelectionChoice choice) {
			_Choices.Add(choice);
		}

		public void Remove(string identifier) {
			_Choices.Remove(identifier);
		}

		public bool Contains(string identifier) {
			return _Choices.Contains(identifier);
		}

		/// <summary>
		/// Index of the identifier
		/// </summary>
		/// <returns>The index of of the <paramref name="identifier"/>. Returns -1 if identifier does not exist in choices.</returns>
		/// <param name="identifier">Identifier.</param>
		public int IndexOf(string identifier) {
			return _Choices.IndexOf(identifier);
		}
	}

	public class SelectionChoice {
		public SelectionChoice(string identifier, string label, string hoverText = null) {
			Identifier = identifier;
			Label = label;
			HoverText = hoverText;
		}
		public readonly string Identifier;
		public string Label;
		public string HoverText;
	}

	/// <summary>
	/// Contains the choices of a Selection
	/// </summary>
	internal class SelectionChoices {
		public SelectionChoices() { }

		public SelectionChoices(IReadOnlyCollection<SelectionChoice> choices) {
			foreach (SelectionChoice choice in choices) {
				Add(choice);
			}
		}

		private readonly OrderedDictionary dictionary = new OrderedDictionary();
		public int Count => dictionary.Count;

		/// <summary>
		/// Gets the <see cref="T:StardewConfigFramework.Options.SelectionChoices"/> at the specified index.
		/// </summary>
		/// <param name="index">Index.</param>
		public SelectionChoice this[int index] => dictionary[index] as SelectionChoice;

		/// <summary>
		/// Gets the <see cref="T:StardewConfigFramework.Options.SelectionChoices"/> with the specified identifier.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		public SelectionChoice this[string identifier] => dictionary[identifier] as SelectionChoice;

		public void Insert(int index, SelectionChoice choice) {
			dictionary.Remove(choice.Identifier);
			dictionary.Insert(index, choice.Identifier, choice);
		}

		public void Add(SelectionChoice choice) {
			dictionary.Remove(choice.Identifier);
			dictionary.Add(choice.Identifier, choice);
		}

		/// <summary>
		/// Remove the specified identifier.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		public void Remove(string identifier) {
			dictionary.Remove(identifier);
		}

		public bool Contains(string identifier) {
			return dictionary.Contains(identifier);
		}

		/// <summary>
		/// Index of the identifier
		/// </summary>
		/// <returns>The index of of the <paramref name="identifier"/>. Returns -1 if identifier does not exist in choices.</returns>
		/// <param name="identifier">Identifier.</param>
		public int IndexOf(string identifier) {
			for (int i = 0; i < dictionary.Count; i++) {
				if (dictionary[i] == dictionary[identifier])
					return i;
			}
			return -1;
		}

		public IReadOnlyCollection<SelectionChoice> AsList() {
			List<SelectionChoice> list = new List<SelectionChoice>();
			foreach (SelectionChoice choice in dictionary) {
				list.Add(choice);
			}
			return list.AsReadOnly();
		}
	}
}
