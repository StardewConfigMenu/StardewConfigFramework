using StardewConfigFramework.Options;
using StardewModdingAPI;

namespace StardewConfigFramework {
	public class SimpleOptionsPackage: BaseOptionPackage {
		public SimpleOptionsPackage(IMod mod) : base(mod) {
			Tabs.Add(new OptionsTab("main", "Main"));
		}

		private ISCFOrderedDictionary<IConfigOption> OptionList => Tabs[0].Options;

		public T GetOption<T>(string identifier) where T : IConfigOption {
			return Tabs[0].GetOption<T>(identifier);
		}

		public T GetOption<T>(int index) where T : IConfigOption {
			return Tabs[0].GetOption<T>(index);
		}

		public IConfigOption GetOption(string identifier) {
			return OptionList[identifier];
		}

		public IConfigOption GetOption(int index) {
			return OptionList[index];
		}

		public int IndexOfOption(string identifier) {
			return OptionList.IndexOf(identifier);
		}

		public void AddOption(IConfigOption option) {
			OptionList.Add(option);
		}

		public void InsertOption(int index, IConfigOption option) {
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
