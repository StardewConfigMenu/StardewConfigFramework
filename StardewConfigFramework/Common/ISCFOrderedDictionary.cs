using System;
using System.Collections.Generic;

namespace StardewConfigFramework {
	public interface ISCFOrderedDictionary<T>: IList<T>, IDictionary<string, T> where T : SCFObject {
		int IndexOf(string identifier);
		bool Contains(string identifier);
		void Add(IList<T> items);
		new void Clear();
		new int Count { get; }
		new IEnumerator<T> GetEnumerator();
	}
}