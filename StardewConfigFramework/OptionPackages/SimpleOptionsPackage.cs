using StardewConfigFramework.Options;
using StardewModdingAPI;

namespace StardewConfigFramework {
	public class SimpleOptionsPackage: BaseOptionPackage {
		public SimpleOptionsPackage(IMod mod) : base(mod) {
			Tabs.Add(new OptionsTab(""));
		}

		private ISCFOrderedDictionary<ModOption> OptionList => Tabs[0].Options;

		public T GetOption<T>(string identifier) where T : ModOption {
			return Tabs[0].GetOption<T>(identifier);
		}

		public T GetOption<T>(int index) where T : ModOption {
			return Tabs[0].GetOption<T>(index);
		}

		public ModOption GetOption(string identifier) {
			return OptionList[identifier];
		}

		public ModOption GetOption(int index) {
			return OptionList[index];
		}

		public int IndexOfOption(string identifier) {
			return OptionList.IndexOf(identifier);
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

		public bool RemoveOption(string identifier) {
			return OptionList.Remove(identifier);
		}

		public bool ContainsOption(string identifier) {
			return OptionList.Contains(identifier);
		}
	}
}
