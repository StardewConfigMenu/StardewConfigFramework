using System;
using System.Collections;
using System.Collections.Generic;

namespace StardewConfigFramework.Options {

	public class ConfigSelection: ConfigOption, IConfigSelection {
		public event SelectionHandler SelectionDidChange;

		private ISCFOrderedDictionary<ISelectionChoice> _Choices = new SCFOrderedDictionary<ISelectionChoice>();
		public ISCFOrderedDictionary<ISelectionChoice> Choices => _Choices;

		public ConfigSelection(string identifier, string labelText, IList<ISelectionChoice> choices = null, int defaultSelection = 0, bool enabled = true) : base(identifier, labelText, enabled) {
			if (choices != null) {
				foreach (ISelectionChoice choice in choices) {
					Choices.Add(choice);
				}

				CheckValidIndex(defaultSelection);
				_SelectedIndex = defaultSelection;
			}
		}

		public ConfigSelection(string identifier, string labelText, IList<ISelectionChoice> choices, string defaultSelection, bool enabled = true) : base(identifier, labelText, enabled) {
			if (choices != null) {
				foreach (ISelectionChoice choice in choices) {
					Choices.Add(choice);
				}
				CheckValidIdentifier(defaultSelection);
				_SelectedIndex = Choices.IndexOf(defaultSelection);
			}
		}

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

				int index = Choices.IndexOf(value);
				if (_SelectedIndex == index)
					return;

				_SelectedIndex = index;
				SelectionDidChange?.Invoke(this);
			}
		}

		private void CheckValidIndex(int value) {
			if (Choices.Count == 0 && value == 0) {
			} else if (value >= Choices.Count || value < 0) {
				throw new IndexOutOfRangeException("Selection is out of range of Choices");
			}
		}

		private void CheckValidIdentifier(string value) {
			if (!Choices.Contains(value))
				throw new KeyNotFoundException("Identifier does not exist in Choices");
		}
	}

	public interface ISelectionChoice: SCFObject {
		string HoverText { get; }
	}

	public class SelectionChoice: ISelectionChoice {
		public SelectionChoice(string identifier, string label, string hoverText = null) {
			Identifier = identifier;
			Label = label;
			HoverText = hoverText;
		}
		public string Identifier { get; }
		public string Label { get; }
		public string HoverText { get; }
	}
}
