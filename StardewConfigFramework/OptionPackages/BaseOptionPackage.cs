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

		public int IndexOf(OptionsTab item) {
			return Tabs.IndexOf(item);
		}

		public void Insert(int index, OptionsTab item) {
			Tabs.Insert(index, item);
		}

		public void RemoveAt(int index) {
			Tabs.RemoveAt(index);
		}

		public void Add(OptionsTab item) {
			Tabs.Add(item);
		}

		public void Clear() {
			Tabs.Clear();
		}

		public bool Contains(OptionsTab item) {
			return Tabs.Contains(item);
		}

		public void CopyTo(OptionsTab[] array, int arrayIndex) {
			Tabs.CopyTo(array, arrayIndex);
		}

		public bool Remove(OptionsTab item) {
			return Tabs.Remove(item);
		}

		public IEnumerator<OptionsTab> GetEnumerator() {
			return Tabs.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return Tabs.GetEnumerator();
		}
	}
}
