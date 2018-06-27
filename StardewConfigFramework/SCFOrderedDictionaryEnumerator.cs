using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace StardewConfigFramework {
	public class SCFDictionaryEnumerator<T>: IEnumerator<KeyValuePair<string, T>> {
		public SCFDictionaryEnumerator(OrderedDictionary orderedDictionary) {
			Enumerator = orderedDictionary.GetEnumerator();
		}

		private IDictionaryEnumerator Enumerator;

		public KeyValuePair<string, T> Current {
			get {
				var key = (string) Enumerator.Key;
				var value = (T) Enumerator.Value;
				return new KeyValuePair<string, T>(key, value);
			}
		}

		object IEnumerator.Current => Enumerator.Current;

		public void Dispose() { }

		public bool MoveNext() {
			return Enumerator.MoveNext();
		}

		public void Reset() {
			Enumerator.Reset();
		}
	}
}

namespace StardewConfigFramework {
	public class SCFListEnumerator<T>: IEnumerator<T> {
		public SCFListEnumerator(OrderedDictionary orderedDictionary) {
			Enumerator = orderedDictionary.GetEnumerator();
		}

		private IDictionaryEnumerator Enumerator;

		public T Current => (T) Enumerator.Value;

		object IEnumerator.Current => Enumerator.Current;

		public bool MoveNext() {
			return Enumerator.MoveNext();
		}

		public void Reset() {
			Enumerator.Reset();
		}

		public void Dispose() { }
	}
}