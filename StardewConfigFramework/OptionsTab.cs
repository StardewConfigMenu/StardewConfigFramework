using System;
using System.Collections.Generic;
using StardewConfigFramework.Options;
using StardewModdingAPI;

namespace StardewConfigFramework {
	public class OptionsTab {
		public OptionsTab(string label) {
			Label = label;
		}

		public string Label;
		public IReadOnlyList<ModOption> OptionList => _OptionList.AsReadOnly();
		internal List<ModOption> _OptionList = new List<ModOption>();

		public T GetOption<T>(string identifier) where T : ModOption {
			return GetOption(identifier) as T;
		}

		public T GetOption<T>(int index) where T : ModOption {
			return GetOption(index) as T;
		}

		public ModOption GetOption(string identifier) {
			return _OptionList[IndexOf(identifier)];
		}

		public ModOption GetOption(int index) {
			return _OptionList[index];
		}

		public int IndexOf(string identifier) {
			return _OptionList.FindIndex((x) => x.Identifier == identifier);
		}

		public Type GetType(string identifier) {
			return GetOption(identifier).GetType();
		}

		public Type GetType(int index) {
			return _OptionList[index].GetType();
		}

		public void AddOption(ModOption option) {
			RemoveOption(option.Identifier);
			_OptionList.Add(option);
		}

		public void InsertOption(ModOption option, int index) {
			RemoveOption(option.Identifier);
			_OptionList.Insert(index, option);
		}

		public void InsertOptionBefore(ModOption option, string identifier) {
			RemoveOption(option.Identifier);
			var indexOfTarget = IndexOf(identifier);
			_OptionList.Insert(indexOfTarget, option);
		}

		public ModOption RemoveOption(int index) {
			var old = _OptionList[index];
			_OptionList.RemoveAt(index);
			return old;
		}

		public ModOption RemoveOption(string identifier) {
			if (!Contains(identifier))
				return null;

			var old = GetOption(identifier);
			_OptionList.Remove(old);
			return old;
		}

		public bool Contains(string identifier) {
			return IndexOf(identifier) != -1;
		}
	}
}
