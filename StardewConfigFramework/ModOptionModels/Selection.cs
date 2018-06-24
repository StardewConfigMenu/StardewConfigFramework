using System;
using System.Collections.Generic;

namespace StardewConfigFramework.Options {
	public class Selection: ModOption {
		public delegate void Handler(Selection selection, string selectedIdentifier);
		public event Handler SelectionDidChange;

		internal SelectionChoices _Choices { get; private set; } = new SelectionChoices();

		/// <summary>
		/// Returns a Read Only copy of the choices collection
		/// </summary>
		/// <value>The choices.</value>
		public IReadOnlyList<SelectionChoice> Choices => _Choices.AsList();

		public Selection(string identifier, string labelText, IReadOnlyList<SelectionChoice> choices = null, int defaultSelection = 0, bool enabled = true) : base(identifier, labelText, enabled) {
			if (choices != null) {
				_Choices = new SelectionChoices(choices);
				SelectionIndex = defaultSelection;
			}
		}

		public Selection(string identifier, string labelText, IReadOnlyList<SelectionChoice> choices, string defaultSelection, bool enabled = true) : base(identifier, labelText, enabled) {
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
				SelectionDidChange?.Invoke(this, SelectedIdentifier);
			}
		}

		public SelectionChoice SelectedChoice => _Choices[_SelectedIndex];

		public string SelectedIdentifier {
			get => SelectedChoice.Identifier;
			set {
				if (!_Choices.Contains(value))
					throw new KeyNotFoundException("Identifier does not exist in Choices");

				int index = _Choices.IndexOf(value);
				if (_SelectedIndex == index)
					return;

				_SelectedIndex = index;
				SelectionDidChange?.Invoke(this, SelectedIdentifier);
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

		public int IndexOfLabel(string label) {
			return _Choices.IndexOfLabel(label);
		}

		public IReadOnlyList<string> GetLabels() {
			return _Choices.GetLabels();
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
}
