
namespace StardewConfigFramework.Options {

	public class ConfigAction: ConfigOption, IConfigAction {

		public event ActionHandler ActionWasTriggered;

		public ConfigAction(string identifier, string labelText, ButtonType type, bool enabled = true) : base(identifier, labelText, enabled) {
			ButtonType = type;
		}

		public ButtonType _Type;
		public ButtonType ButtonType { get => _Type; set => _Type = value; }

		public void Trigger() {
			ActionWasTriggered?.Invoke(this);
		}
	}
}
