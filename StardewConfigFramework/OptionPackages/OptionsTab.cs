using System.Collections;
using System.Collections.Generic;
using StardewConfigFramework.Options;

namespace StardewConfigFramework {
	public class OptionsTab: IOptionsTab {

		public ISCFOrderedDictionary<IConfigOption> Options => new SCFOrderedDictionary<IConfigOption>();

		private string _Label;

		public string Label { get => _Label; set => _Label = value; }

		public OptionsTab(string label) {
			Label = label;
		}

		public T GetOption<T>(string identifier) where T : IConfigOption {
			return (T) Options[identifier];
		}

		public T GetOption<T>(int index) where T : IConfigOption {
			return (T) Options[index];
		}
	}
}
