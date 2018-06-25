﻿using System.Collections;
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
		public bool IsReadOnly => false;

		/// <summary>
		/// Gets the <see cref="T:StardewConfigFramework.Options.SelectionChoices"/> at the specified index.
		/// </summary>
		/// <param name="index">Index.</param>
		public SelectionChoice this[int index] { get => dictionary[index] as SelectionChoice; set => dictionary[index] = value; }

		/// <summary>
		/// Gets the <see cref="T:StardewConfigFramework.Options.SelectionChoices"/> with the specified identifier.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		public SelectionChoice this[string identifier] { get => dictionary[identifier] as SelectionChoice; set => dictionary[identifier] = value; }

		public void Insert(int index, SelectionChoice choice) {
			dictionary.Insert(index, choice.Identifier, choice);
		}

		public void Add(SelectionChoice choice) {
			dictionary.Add(choice.Identifier, choice);
		}

		/// <summary>
		/// Remove the specified identifier.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		public bool Remove(string identifier) {
			if (!Contains(identifier))
				return false;

			dictionary.Remove(identifier);
			return true;
		}

		public bool Remove(SelectionChoice item) {
			if (!Contains(item))
				return false;

			Remove(item.Identifier);
			return true;
		}

		public void RemoveAt(int index) {
			dictionary.RemoveAt(index);
		}

		public void Clear() {
			dictionary.Clear();
		}

		public bool Contains(string identifier) {
			return dictionary.Contains(identifier);
		}

		public bool Contains(SelectionChoice choice) {
			foreach (SelectionChoice item in dictionary) {
				if (item == choice)
					return true;
			}
			return false;
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

		public int IndexOf(SelectionChoice item) {
			return IndexOf(item.Identifier);
		}

		public void CopyTo(SelectionChoice[] array, int arrayIndex) {
			dictionary.CopyTo(array, arrayIndex);
		}

		public IEnumerator<SelectionChoice> GetEnumerator() {
			return dictionary.GetEnumerator() as IEnumerator<SelectionChoice>;
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return dictionary.GetEnumerator();
		}
	}
}
