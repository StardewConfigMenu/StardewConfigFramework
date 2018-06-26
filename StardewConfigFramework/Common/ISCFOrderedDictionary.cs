using System;
using System.Collections.Generic;

namespace StardewConfigFramework {
	public interface ISCFOrderedDictionary<T>: IList<T>, IDictionary<string, T> where T : SCFObject {
		int IndexOf(string identifier);
		bool Contains(string identifier);
	}
}