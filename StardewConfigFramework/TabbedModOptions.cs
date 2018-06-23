using System;
using System.Collections.Generic;
using StardewConfigFramework.Options;
using StardewModdingAPI;

namespace StardewConfigFramework {
	using IOptionList = IList<ModOption>;
	using OptionList = List<ModOption>;

	public class TabbedModOptions: IModOptions {
		public TabbedModOptions(Mod mod) {
			this.ModManifest = mod.ModManifest;
		}

		public IManifest ModManifest { get; }
		private List<OptionList> Tabs = new List<OptionList>();
		public int TabCount => Tabs.Count;

		public IOptionList GetOptionListForTab(int tabIndex) {
			return Tabs[tabIndex].AsReadOnly();
		}

		public T GetOptionWithIdentifier<T>(int tabIndex, string identifier) where T : ModOption {
			return GetOptionWithIdentifier(tabIndex, identifier) as T;
		}

		public ModOption GetOptionWithIdentifier(int tabIndex, string identifier) {
			return Tabs[tabIndex].Find(x => x.Identifier == identifier);
		}

		public Type GetTypeOfIdentifier(int tabIndex, string identifier) {
			return GetOptionWithIdentifier(tabIndex, identifier).GetType();
		}

		public void AddOption(int tabIndex, ModOption option) {
			RemoveOptionWithIdentifier(tabIndex, option.Identifier);
			Tabs[tabIndex].Add(option);
		}

		public void InsertOption(int tabIndex, ModOption option, int optionIndex) {
			RemoveOptionWithIdentifier(tabIndex, option.Identifier);
			Tabs[tabIndex].Insert(optionIndex, option);
		}

		public ModOption RemoveOptionAtIndex(int tabIndex, int optionIndex) {
			var old = Tabs[tabIndex][optionIndex];
			Tabs[tabIndex].RemoveAt(optionIndex);
			return old;
		}

		public ModOption RemoveOptionWithIdentifier(int tabIndex, string identifier) {
			var old = GetOptionWithIdentifier(tabIndex, identifier);
			Tabs[tabIndex].Remove(old);
			return old;
		}
	}
}
