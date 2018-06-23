using StardewModdingAPI;
using StardewConfigFramework.Options;
using System.Collections.Generic;
using System;

namespace StardewConfigFramework {
	public class SimpleOptionsPackage: IOptionsPackage {
		public SimpleOptionsPackage(Mod mod) {
			ModManifest = mod.ModManifest;
		}

		public IManifest ModManifest { get; private set; }
		public IList<OptionsTab> Tabs => _Tabs.AsReadOnly();
		private List<OptionsTab> _Tabs => new List<OptionsTab> { Tab };
		public IReadOnlyCollection<ModOption> OptionList => Tab.OptionList;
		private OptionsTab Tab = new OptionsTab("");
		public int TabCount { get; } = 1;

		public T GetOptionWithIdentifier<T>(string identifier) where T : ModOption {
			return Tab.GetOptionWithIdentifier<T>(identifier);
		}

		public ModOption GetOptionWithIdentifier(string identifier) {
			return Tab.GetOptionWithIdentifier(identifier);
		}

		public Type GetTypeOfIdentifier(string identifier) {
			return Tab.GetTypeOfIdentifier(identifier);
		}

		public void AddOption(ModOption option) {
			Tab.AddOption(option);
		}

		public void InsertOption(ModOption option, int optionIndex) {
			Tab.InsertOption(option, optionIndex);
		}

		public ModOption RemoveOptionAtIndex(int optionIndex) {
			return Tab.RemoveOptionAtIndex(optionIndex);
		}

		public ModOption RemoveOptionWithIdentifier(string identifier) {
			return Tab.RemoveOptionWithIdentifier(identifier);
		}
	}
}
