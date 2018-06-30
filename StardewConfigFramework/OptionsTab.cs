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

		public T GetOption<T>(string identifier) where T : IConfigOption {
			return (T) Options[identifier];
		}

		public T GetOption<T>(int index) where T : IConfigOption {
			return (T) Options[index];
		}
	}
}
