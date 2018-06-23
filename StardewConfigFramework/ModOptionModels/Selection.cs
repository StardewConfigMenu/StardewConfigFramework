using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace StardewConfigFramework.Options {
	public class Selection: ModOption {
		public delegate void Handler(string componentIdentifier, string selectionIdentifier);
		public event Handler ValueDidChange;

		public SelectionChoices Choices { get; private set; } = new SelectionChoices();
		public Dictionary<String, String> HoverTextDictionary = null;

		public Selection(string identifier, string labelText, SelectionChoices choices = null, int defaultSelection = 0, bool enabled = true) : base(identifier, labelText, enabled) {
			if (choices != null) {
				Choices = choices;
				SelectionIndex = defaultSelection;
			}
		}

		public Selection(string identifier, string labelText, SelectionChoices choices, string defaultSelection, bool enabled = true) : base(identifier, labelText, enabled) {
			if (choices != null) {
				Choices = choices;
				if (choices.Count > 0)
					SelectedIdentifier = defaultSelection;
			}
		}

		private int _SelectedIndex = 0;
		public int SelectionIndex {
			get {
				return _SelectedIndex;
			}
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
			get {
				return Choices.IdentifierOf(_SelectedIndex);
			}
			set {
				if (!Choices.Contains(value))
					throw new KeyNotFoundException("Identifier does not exist in Choices");

				if (_SelectedIndex != Choices.IndexOf(value)) {
					_SelectedIndex = Choices.IndexOf(value);
					ValueDidChange?.Invoke(Identifier, SelectedIdentifier);
				}
			}
		}
	}

	/// <summary>
	/// Contains the choices of a Selection
	/// </summary>
	public class SelectionChoices {

		private OrderedDictionary dictionary = new OrderedDictionary();
		public int Count => dictionary.Count;

		/// <summary>
		/// Gets or sets the Label with the specified key.
		/// </summary>
		/// <param name="key">Key.</param>
		public string this[int key] {
			get {
				return dictionary[key] as string;
			}
			set {
				dictionary[key] = value;
			}
		}

		/// <summary>
		/// Gets or sets the Label with the specified identifier.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		public string this[string identifier] {
			get {
				return dictionary[identifier] as string;
			}
			set {
				dictionary[identifier] = value;
			}
		}

		public void Insert(int index, string identifier, string label) {
			dictionary.Remove(identifier);
			dictionary.Insert(index, identifier, label);
		}

		public void Add(string identifier, string label) {
			dictionary.Remove(identifier);
			dictionary.Add(identifier, label);
		}

		public void Replace(string identifier, string label) {
			var index = IndexOf(identifier);
			if (index != -1) {
				dictionary.Remove(identifier);
				dictionary.Insert(index, identifier, label);
			} else
				dictionary.Add(identifier, label);
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

		public int IndexOfLabel(string label) {
			return Labels.IndexOf(label);
		}

		public string IdentifierOfLabel(string label) {
			return IdentifierOf(Labels.IndexOf(label));
		}

		/// <summary>
		/// Gets the Index of the identifier.
		/// </summary>
		/// <returns>the index, or -1 if not found.</returns>
		/// <param name="identifier">Identifier.</param>
		public int IndexOf(string identifier) {
			return Identifiers.IndexOf(identifier);
		}

		public string IdentifierOf(int index) {
			if (dictionary.Keys.Count == 0 || index < 0 || index >= dictionary.Keys.Count)
				return string.Empty;
			String[] myKeys = new String[dictionary.Keys.Count];
			dictionary.Keys.CopyTo(myKeys, 0);
			return myKeys[index];
		}

		public string LabelOf(int index) {
			return this[index];
		}

		public string LabelOf(string identifier) {
			return this[identifier];
		}

		public IList<string> Identifiers {
			get {
				if (dictionary.Keys.Count == 0)
					return new List<string>();

				String[] myKeys = new String[dictionary.Keys.Count];
				dictionary.Keys.CopyTo(myKeys, 0);
				var keys = new List<string>(myKeys);
				return keys.AsReadOnly();
			}
		}

		public IList<string> Labels {
			get {
				if (dictionary.Values.Count == 0)
					return new List<string>();

				String[] myValues = new String[dictionary.Values.Count];
				dictionary.Values.CopyTo(myValues, 0);
				var labels = new List<string>(myValues);
				return labels.AsReadOnly();
			}
		}
	}
}
