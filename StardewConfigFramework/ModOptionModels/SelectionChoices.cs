using System.Collections.Generic;
using System.Collections.Specialized;

namespace StardewConfigFramework.Options {
	/// <summary>
	/// Contains the choices of a Selection
	/// </summary>
	internal class SelectionChoices {
		public SelectionChoices() { }

		public SelectionChoices(IReadOnlyList<SelectionChoice> choices) {
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

		public int IndexOfLabel(string label) {
			for (int i = 0; i < dictionary.Count; i++) {
				if (this[i].Label == label)
					return i;
			}
			return -1;
		}

		public IReadOnlyList<SelectionChoice> AsList() {
			List<SelectionChoice> list = new List<SelectionChoice>();
			foreach (SelectionChoice choice in dictionary) {
				list.Add(choice);
			}
			return list.AsReadOnly();
		}

		public IReadOnlyList<string> GetLabels() {
			List<string> list = new List<string>();
			foreach (SelectionChoice choice in dictionary) {
				list.Add(choice.Label);
			}
			return list.AsReadOnly();
		}
	}
}
