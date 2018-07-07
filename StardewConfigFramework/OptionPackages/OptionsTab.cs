using System.Collections;
using System.Collections.Generic;
using StardewConfigFramework.Options;

namespace StardewConfigFramework {
	public class OptionsTab: IOptionsTab {

		private ISCFOrderedDictionary<IConfigOption> _Options = new SCFOrderedDictionary<IConfigOption>();
		public ISCFOrderedDictionary<IConfigOption> Options => _Options;

		private string _Label;

		public string Label { get => _Label; set => _Label = value; }

		private string _Identifier;

		public string Identifier => _Identifier;

		public OptionsTab(string identifier, string label) {
			_Identifier = identifier;
			_Label = label;
		}

		public T GetOption<T>(string identifier) where T : IConfigOption {
			return (T) Options[identifier];
		}

		public T GetOption<T>(int index) where T : IConfigOption {
			return (T) Options[index];
		}
	}
}
