using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using StardewConfigFramework.Options;

namespace StardewConfigFramework {
	public class OptionsTab: IList<ModOption>, IDictionary<string, ModOption> {

		private readonly OrderedIdentifierDictionary<ModOption> Options = new OrderedIdentifierDictionary<ModOption>();

		public OptionsTab(string label) {
			Label = label;
		}

		public string Label;

		public int Count => Options.Count;

		public bool IsReadOnly => Options.IsReadOnly;

		public ICollection<string> Keys => Options.Keys;

		public ICollection<ModOption> Values => Options.Values;

		public ModOption this[string key] { get => Options[key]; set => Options[key] = value; }
		public ModOption this[int index] { get => Options[index]; set => Options[index] = value; }

		public T GetOption<T>(string identifier) where T : ModOption {
			return this[identifier] as T;
		}

		public T GetOption<T>(int index) where T : ModOption {
			return this[index] as T;
		}

		/// <summary>
		/// Index of the identifier
		/// </summary>
		/// <returns>The index of of the <paramref name="identifier"/>. Returns -1 if identifier does not exist.</returns>
		/// <param name="identifier">Identifier.</param>
		public int IndexOf(string identifier) {
			return Options.IndexOf(identifier);
		}

		public int IndexOf(ModOption option) {
			return Options.IndexOf(option);
		}

		public void Insert(int index, ModOption option) {
			Options.Insert(index, option);
		}

		public void RemoveAt(int index) {
			Options.RemoveAt(index);
		}

		public void Add(ModOption option) {
			Options.Add(option);
		}

		public void Clear() {
			Options.Clear();
		}

		public bool Contains(string identifier) {
			return Options.Contains(identifier);
		}

		public bool Contains(ModOption option) {
			return Options.Contains(option);
		}

		public void CopyTo(ModOption[] array, int arrayIndex) {
			Options.CopyTo(array, arrayIndex);
		}

		public bool Remove(ModOption option) {
			return Options.Remove(option);
		}

		public IEnumerator<ModOption> GetEnumerator() {
			return Options.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return Options.GetEnumerator();
		}

		public void Add(string key, ModOption value) {
			Options.Add(key, value);
		}

		public bool ContainsKey(string key) {
			return Options.ContainsKey(key);
		}

		public bool Remove(string key) {
			return Options.Remove(key);
		}

		public bool TryGetValue(string key, out ModOption value) {
			return Options.TryGetValue(key, out value);
		}

		public void Add(KeyValuePair<string, ModOption> option) {
			Options.Add(option);
		}

		public bool Contains(KeyValuePair<string, ModOption> option) {
			return Options.Contains(option);
		}

		public void CopyTo(KeyValuePair<string, ModOption>[] array, int arrayIndex) {
			Options.CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<string, ModOption> option) {
			return Options.Remove(option);
		}

		IEnumerator<KeyValuePair<string, ModOption>> IEnumerable<KeyValuePair<string, ModOption>>.GetEnumerator() {
			return ((IDictionary<string, ModOption>) Options).GetEnumerator();
		}
	}
}
