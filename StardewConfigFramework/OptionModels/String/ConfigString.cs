using System;
namespace StardewConfigFramework.Options {
	public class ConfigString: ConfigOption, IConfigString {
		public ConfigString(string identifier, string label, string defaultValue = "", bool enabled = true) : base(identifier, label, enabled) {
			_Value = defaultValue;
		}

		string _Value;
		public string Value {
			get => _Value;
			set {
				if (_Value == value)
					return;

				_Value = value;
				StringWasChanged?.Invoke(this);
			}
		}

		public event StringHandler StringWasChanged;
	}
}
