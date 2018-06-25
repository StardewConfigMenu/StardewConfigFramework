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
		private List<OptionsTab> _Tabs = new List<OptionsTab> { new OptionsTab("") };
		public IReadOnlyList<ModOption> OptionList => Tab.OptionList;
		private OptionsTab Tab => Tabs[0];

		public T GetOption<T>(string identifier) where T : ModOption {
			return Tab.GetOption<T>(identifier);
		}

		public T GetOption<T>(int index) where T : ModOption {
			return Tab.GetOption<T>(index);
		}

		public ModOption GetOption(string identifier) {
			return Tab.GetOption(identifier);
		}

		public ModOption GetOption(int index) {
			return Tab.GetOption(index);
		}

		public int IndexOf(string identifier) {
			return Tab.IndexOf(identifier);
		}

		public Type GetType(string identifier) {
			return Tab.GetType(identifier);
		}

		public Type GetType(int index) {
			return Tab.GetType(index);
		}

		public void AddOption(ModOption option) {
			Tab.AddOption(option);
		}

		public void InsertOption(ModOption option, int index) {
			Tab.InsertOption(option, index);
		}

		public void InsertOptionBefore(ModOption option, string identifier) {
			Tab.InsertOptionBefore(option, identifier);
		}

		public ModOption RemoveOption(int index) {
			return Tab.RemoveOption(index);
		}

		public ModOption RemoveOption(string identifier) {
			return Tab.RemoveOption(identifier);
		}
	}
}
