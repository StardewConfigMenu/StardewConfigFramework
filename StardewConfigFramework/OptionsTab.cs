using System;
using System.Collections.Generic;
using StardewConfigFramework.Options;
using StardewModdingAPI;

namespace StardewConfigFramework {
	public class ModOptionsTab {
		public ModOptionsTab(string label) {
			Label = label;
		}

		public string Label;
		public IList<ModOption> OptionList => _OptionList.AsReadOnly();
		internal List<ModOption> _OptionList = new List<ModOption>();

		public T GetOptionWithIdentifier<T>(string identifier) where T : ModOption {
			return GetOptionWithIdentifier(identifier) as T;
		}

		public ModOption GetOptionWithIdentifier(string identifier) {
			return _OptionList.Find(x => x.Identifier == identifier);
		}

		public Type GetTypeOfIdentifier(string identifier) {
			return GetOptionWithIdentifier(identifier).GetType();
		}

		public void AddOption(ModOption option) {
			RemoveOptionWithIdentifier(option.Identifier);
			_OptionList.Add(option);
		}

		public void InsertOption(ModOption option, int optionIndex) {
			RemoveOptionWithIdentifier(option.Identifier);
			_OptionList.Insert(optionIndex, option);
		}

		public ModOption RemoveOptionAtIndex(int optionIndex) {
			var old = _OptionList[optionIndex];
			_OptionList.RemoveAt(optionIndex);
			return old;
		}

		public ModOption RemoveOptionWithIdentifier(string identifier) {
			var old = GetOptionWithIdentifier(identifier);
			_OptionList.Remove(old);
			return old;
		}
	}
}
