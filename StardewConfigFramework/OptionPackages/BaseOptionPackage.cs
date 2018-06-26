using System.Collections;
using System.Collections.Generic;
using StardewModdingAPI;

namespace StardewConfigFramework {
	public abstract class BaseOptionPackage: IOptionsPackage {
		protected BaseOptionPackage(Mod mod) {
			ModManifest = mod.ModManifest;
		}

		public IManifest ModManifest { get; private set; }
		protected readonly List<OptionsTab> Tabs = new List<OptionsTab>();

		public int Count => Tabs.Count;
		public bool IsReadOnly => false;

		public OptionsTab this[int index] { get => Tabs[index]; set => Tabs[index] = value; }

		public int IndexOf(OptionsTab tab) {
			return Tabs.IndexOf(tab);
		}

		public void Insert(int index, OptionsTab tab) {
			Tabs.Insert(index, tab);
		}

		public void RemoveAt(int index) {
			Tabs.RemoveAt(index);
		}

		public void Add(OptionsTab tab) {
			Tabs.Add(tab);
		}

		public void Clear() {
			Tabs.Clear();
		}

		public bool Contains(OptionsTab tab) {
			return Tabs.Contains(tab);
		}

		public void CopyTo(OptionsTab[] array, int arrayIndex) {
			Tabs.CopyTo(array, arrayIndex);
		}

		public bool Remove(OptionsTab tab) {
			return Tabs.Remove(tab);
		}

		public IEnumerator<OptionsTab> GetEnumerator() {
			return Tabs.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return Tabs.GetEnumerator();
		}
	}
}
