using StardewModdingAPI;
using StardewConfigFramework.Options;
using System.Collections.Generic;
using System.IO;
using System;

namespace StardewConfigFramework {
	using IOptionList = IList<ModOption>;
	using OptionList = List<ModOption>;

	public class SimpleModOptions: IModOptions {
		public SimpleModOptions(Mod mod) {
			this.ModManifest = mod.ModManifest;
		}

		public IManifest ModManifest { get; private set; }
		public IOptionList OptionList => _OptionList.AsReadOnly();
		private OptionList _OptionList { get; set; } = new OptionList();
		public int TabCount { get; } = 1;

		public IOptionList GetOptionListForTab(int optionIndex) {
			if (optionIndex != 1) {
				throw new IndexOutOfRangeException("SimpleModOptions has only 1 tab");
			}
			return OptionList;
		}

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
			this._OptionList.Add(option);
		}

		public void InsertOption(ModOption option, int optionIndex) {
			this.RemoveOptionWithIdentifier(option.Identifier);
			this._OptionList.Insert(optionIndex, option);
		}

		public ModOption RemoveOptionAtIndex(int optionIndex) {
			var old = _OptionList[optionIndex];
			this._OptionList.RemoveAt(optionIndex);
			return old;
		}

		public ModOption RemoveOptionWithIdentifier(string identifier) {
			var old = GetOptionWithIdentifier(identifier);
			_OptionList.Remove(old);
			return old;
		}

		[Obsolete("Saving/Loading settings within the framework is deprecated. Please use SMAPI methods for saving mod settings and use initial values when populating settings menu", true)]
		public static SimpleModOptions LoadUserSettings(Mod mod) {
			mod.Monitor.Log("[StardewConfigFramework] This mod is using deprecated saving & loading methods which will no longer work. Please alert the mod author");
			return new SimpleModOptions(mod);
		}

		[Obsolete("Saving/Loading settings within the framework is deprecated. Please use SMAPI methods for saving mod settings and use initial values when populating settings menu", true)]
		public void SaveUserSettings() { }

		[Obsolete("Saving/Loading settings within the framework is deprecated. Please use SMAPI methods for saving mod settings and use initial values when populating settings menu", true)]
		public static SimpleModOptions LoadCharacterSettings(Mod mod, string farmerName) {
			mod.Monitor.Log("[StardewConfigFramework] This mod is using deprecated saving & loading methods which will no longer work. Please alert the mod author");
			return new SimpleModOptions(mod);
		}

		[Obsolete("Saving/Loading settings within the framework is deprecated. Please use SMAPI methods for saving mod settings and use initial values when populating settings menu", true)]
		public void SaveCharacterSettings(string farmerName) { }
	}
}
