using StardewModdingAPI;
using StardewConfigFramework.Options;
using System;

namespace StardewConfigFramework {
	public class SimpleOptionsPackage: BaseOptionPackage {
		public SimpleOptionsPackage(Mod mod) : base(mod) {
			Tabs.Add(new OptionsTab(""));
		}

		private OptionsTab OptionList => Tabs[0];

		public T GetOption<T>(string identifier) where T : ModOption {
			return OptionList.GetOption<T>(identifier);
		}

		public T GetOption<T>(int index) where T : ModOption {
			return OptionList.GetOption<T>(index);
		}

		public ModOption GetOption(string identifier) {
			return OptionList[identifier];
		}

		public ModOption GetOption(int index) {
			return OptionList[index];
		}

		public int IndexOf(string identifier) {
			return OptionList.IndexOf(identifier);
		}

		public Type GetType(string identifier) {
			return OptionList[identifier].GetType();
		}

		public Type GetType(int index) {
			return OptionList[index].GetType();
		}

		public void AddOption(ModOption option) {
			OptionList.Add(option);
		}

		public void InsertOption(int index, ModOption option) {
			OptionList.Insert(index, option);
		}

		public void RemoveOptionAt(int index) {
			OptionList.RemoveAt(index);
		}

		public void RemoveOption(string identifier) {
			OptionList.Remove(identifier);
		}

		public bool ContainsOption(string identifier) {
			return OptionList.Contains(identifier);
		}
	}
}
