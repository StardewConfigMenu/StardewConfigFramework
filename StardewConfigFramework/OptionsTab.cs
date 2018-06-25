using System.Collections;
using System.Collections.Generic;
using StardewConfigFramework.Options;

namespace StardewConfigFramework {
	public class OptionsTab: IList<ModOption> {
		public OptionsTab(string label) {
			Label = label;
		}

		public string Label;
		private List<ModOption> OptionList = new List<ModOption>();

		public int Count => OptionList.Count;
		public bool IsReadOnly => false;

		public ModOption this[int index] { get => OptionList[index]; set => OptionList[index] = value; }
		public ModOption this[string identifier] {
			get {
				if (!Contains(identifier))
					throw new KeyNotFoundException();

				return OptionList[IndexOf(identifier)];
			}
			set {
				if (!Contains(identifier))
					throw new KeyNotFoundException();

				OptionList[IndexOf(identifier)] = value;
			}
		}

		public T GetOption<T>(string identifier) where T : ModOption {
			return this[identifier] as T;
		}

		public T GetOption<T>(int index) where T : ModOption {
			return this[index] as T;
		}

		public void Add(ModOption option) {
			Remove(option.Identifier);
			OptionList.Add(option);
		}

		public void Insert(int index, ModOption item) {
			var foundIndex = IndexOf(item.Identifier);
			OptionList.Insert(index, item);

			if (foundIndex != -1) {
				RemoveAt(foundIndex < index ? foundIndex : foundIndex + 1);
			}
		}

		public bool Remove(ModOption item) {
			return OptionList.Remove(item);
		}

		public void RemoveAt(int index) {
			OptionList.RemoveAt(index);
		}

		public void Remove(string identifier) {
			if (!Contains(identifier))
				return;

			OptionList.Remove(this[identifier]);
		}

		public bool Contains(ModOption item) {
			return OptionList.Contains(item);
		}

		public bool Contains(string identifier) {
			return IndexOf(identifier) != -1;
		}

		public int IndexOf(ModOption item) {
			return OptionList.IndexOf(item);
		}

		public int IndexOf(string identifier) {
			return OptionList.FindIndex((x) => x.Identifier == identifier);
		}

		public void Clear() {
			OptionList.Clear();
		}

		public void CopyTo(ModOption[] array, int arrayIndex) {
			OptionList.CopyTo(array, arrayIndex);
		}

		public IEnumerator<ModOption> GetEnumerator() {
			return OptionList.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return OptionList.GetEnumerator();
		}
	}
}
