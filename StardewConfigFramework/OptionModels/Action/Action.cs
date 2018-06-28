
namespace StardewConfigFramework.Options {

	public class Action: ModOption, IAction {

		public event ActionHandler ActionWasTriggered;

		public Action(string identifier, string labelText, ButtonType type, bool enabled = true) : base(identifier, labelText, enabled) {
			ButtonType = type;
		}

		public ButtonType _Type;
		public ButtonType ButtonType { get => _Type; set => _Type = value; }

		public void Trigger() {
			ActionWasTriggered?.Invoke(this);
		}
	}
}
