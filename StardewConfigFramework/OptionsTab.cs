using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using StardewConfigFramework.Options;

namespace StardewConfigFramework {
	public class OptionsTab: IList<ModOption>, IDictionary<string, ModOption> {
		public OptionsTab(string label) {
			Label = label;
		}

		public string Label;
		private readonly OrderedDictionary OptionList = new OrderedDictionary();

		public int Count => OptionList.Count;
		public bool IsReadOnly => false;

		public ICollection<string> Keys => OptionList.Keys as ICollection<string>;

		public ICollection<ModOption> Values => OptionList.Values as ICollection<ModOption>;

		public ModOption this[int index] { get => OptionList[index] as ModOption; set => OptionList[index] = value; }
		public ModOption this[string identifier] { get => OptionList[identifier] as ModOption; set => OptionList[identifier] = value; }

		public T GetOption<T>(string identifier) where T : ModOption {
			return this[identifier] as T;
		}

		public T GetOption<T>(int index) where T : ModOption {
			return this[index] as T;
		}

		public void Add(ModOption option) {
			OptionList.Add(option.Identifier, option);
		}

		public void Insert(int index, ModOption option) {
			OptionList.Insert(index, option.Identifier, option);
		}

		public bool Remove(string identifier) {
			if (!Contains(identifier)) {
				return false;
			}
			OptionList.Remove(identifier);
			return true;
		}

		public bool Remove(ModOption option) {
			return Remove(option.Identifier);
		}

		public void RemoveAt(int index) {
			OptionList.RemoveAt(index);
		}

		public bool Contains(ModOption option) {
			return OptionList.Contains(option);
		}

		public bool Contains(string identifier) {
			return IndexOf(identifier) != -1;
		}

		public int IndexOf(ModOption option) {
			return IndexOf(option.Identifier);
		}

		public int IndexOf(string identifier) {
			for (int i = 0; i < OptionList.Count; i++) {
				if (this[i].Identifier == identifier)
					return i;
			}
			return -1;
		}

		public void Clear() {
			OptionList.Clear();
		}

		public void CopyTo(ModOption[] array, int arrayIndex) {
			OptionList.CopyTo(array, arrayIndex);
		}

		public IEnumerator<ModOption> GetEnumerator() {
			return OptionList.GetEnumerator() as IEnumerator<ModOption>;
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return OptionList.GetEnumerator();
		}

		public void Add(string identifier, ModOption option) {
			OptionList.Add(identifier, option);
		}

		public bool ContainsKey(string identifier) {
			return OptionList.Contains(identifier);
		}

		public bool TryGetValue(string identifier, out ModOption option) {
			if (!Contains(identifier)) {
				option = null;
				return false;
			}

			option = this[identifier];
			return true;
		}

		public void Add(KeyValuePair<string, ModOption> item) {
			OptionList.Add(item.Key, item.Value);
		}

		public bool Contains(KeyValuePair<string, ModOption> item) {
			return OptionList.Contains(item.Key);
		}

		public void CopyTo(KeyValuePair<string, ModOption>[] array, int arrayIndex) {
			OptionList.CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<string, ModOption> item) {
			return Remove(item.Key);
		}

		IEnumerator<KeyValuePair<string, ModOption>> IEnumerable<KeyValuePair<string, ModOption>>.GetEnumerator() {
			return OptionList.GetEnumerator() as IEnumerator<KeyValuePair<string, ModOption>>;
		}
	}
}
