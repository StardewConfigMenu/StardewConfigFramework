using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace StardewConfigFramework.Options {
	/// <summary>
	/// Contains the choices of a Selection
	/// </summary>
	internal class SelectionChoices: IList<SelectionChoice> {
		public SelectionChoices() { }

		public SelectionChoices(IReadOnlyList<SelectionChoice> choices) {
			foreach (SelectionChoice choice in choices) {
				Add(choice);
			}
		}

		private readonly OrderedDictionary dictionary = new OrderedDictionary();
		public int Count => dictionary.Count;

		public bool IsReadOnly => throw new System.NotImplementedException();

		/// <summary>
		/// Gets the <see cref="T:StardewConfigFramework.Options.SelectionChoices"/> at the specified index.
		/// </summary>
		/// <param name="index">Index.</param>
		public SelectionChoice this[int index] { get => dictionary[index] as SelectionChoice; set => dictionary[index] = value; }

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

		public void Clear() {
			dictionary.Clear();
		}

		public bool Contains(string identifier) {
			return dictionary.Contains(identifier);
		}

		public bool Contains(SelectionChoice choice) {
			return dictionary.Contains(choice.Identifier);
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

		public int IndexOf(SelectionChoice item) {
			return IndexOf(item.Identifier);
		}

		public void RemoveAt(int index) {
			dictionary.RemoveAt(index);
		}

		public void CopyTo(SelectionChoice[] array, int arrayIndex) {
			dictionary.CopyTo(array, arrayIndex);
		}

		public bool Remove(SelectionChoice item) {
			if (dictionary.Contains(item)) {
				dictionary.Remove(item.Identifier);
				return true;
			} else {
				return false;
			}
		}

		public IEnumerator<SelectionChoice> GetEnumerator() {
			return dictionary.GetEnumerator() as IEnumerator<SelectionChoice>;
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return dictionary.GetEnumerator();
		}
	}
}
