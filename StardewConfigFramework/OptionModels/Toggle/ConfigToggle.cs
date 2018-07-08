
namespace StardewConfigFramework.Options {

	public class ConfigToggle: ConfigOption, IConfigToggle {
		public event ToggleHandler StateDidChange;

		public ConfigToggle(string identifier, string labelText, bool isOn = true, bool enabled = true) : base(identifier, labelText, enabled) {
			IsOn = isOn;
		}

		public bool IsOn {
			get {
				return _isOn;
			}
			set {
				if (_isOn == value)
					return;

				_isOn = value;
				StateDidChange?.Invoke(this);
			}
		}

		private bool _isOn;

		public void Toggle() {
			IsOn = !IsOn;
		}
	}
}
