using System;
using System.Collections.Generic;

namespace StardewConfigFramework {
	public interface IOrderedDictionary<T>: IList<T>, IDictionary<string, T> where T : SCFObject {
		int IndexOf(string identifier);
		bool Contains(string identifier);
		void Add(IList<T> items);
		new void Clear();
		new int Count { get; }
		new IEnumerator<T> GetEnumerator();
		event OrderedDictionaryContentsDidChange<T> ContentsDidChange;
	}

	public delegate void OrderedDictionaryContentsDidChange<T>(IOrderedDictionary<T> orderedDictionary) where T : SCFObject;
}