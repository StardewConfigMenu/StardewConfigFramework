using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using StardewConfigFramework.Options;

namespace StardewConfigFramework {
	public class OptionsTab: OrderedIdentifierDictionary<ModOption> {
		public OptionsTab(string label) {
			Label = label;
		}

		public string Label;

		public T GetOption<T>(string identifier) where T : ModOption {
			return this[identifier] as T;
		}

		public T GetOption<T>(int index) where T : ModOption {
			return this[index] as T;
		}
	}
}
