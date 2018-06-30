using System.Collections;
using System.Collections.Generic;
using StardewConfigFramework.Options;

namespace StardewConfigFramework {
	public class OptionsTab {

		public readonly ISCFOrderedDictionary<IConfigOption> Options = new SCFOrderedDictionary<IConfigOption>();

		public OptionsTab(string label) {
			Label = label;
		}

		public string Label;

		public T GetOption<T>(string identifier) where T : ConfigOption {
			return Options[identifier] as T;
		}

		public T GetOption<T>(int index) where T : ConfigOption {
			return Options[index] as T;
		}
	}
}
