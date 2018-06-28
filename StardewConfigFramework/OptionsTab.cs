using System.Collections;
using System.Collections.Generic;
using StardewConfigFramework.Options;

namespace StardewConfigFramework {
	public class OptionsTab {

		public readonly ISCFOrderedDictionary<ModOption> Options = new SCFOrderedDictionary<ModOption>();

		public OptionsTab(string label) {
			Label = label;
		}

		public string Label;

		public T GetOption<T>(string identifier) where T : ModOption {
			return Options[identifier] as T;
		}

		public T GetOption<T>(int index) where T : ModOption {
			return Options[index] as T;
		}
	}
}
