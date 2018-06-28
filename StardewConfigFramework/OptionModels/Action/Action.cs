
namespace StardewConfigFramework.Options {

	public class Action: ModOption, IAction {

		public event Handler ActionWasTriggered;

		public Action(string identifier, string labelText, ActionType type, bool enabled = true) : base(identifier, labelText, enabled) {
			Type = type;
		}

		public ActionType _Type;
		public ActionType Type { get => _Type; set => _Type = value }

		public void Trigger() {
			ActionWasTriggered?.Invoke(this);
		}
	}
}
