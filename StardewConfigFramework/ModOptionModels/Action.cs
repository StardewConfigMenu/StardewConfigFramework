
namespace StardewConfigFramework.Options {

	public class Action: ModOption {
		public delegate void Handler(string identifier);
		public enum ActionType {
			OK, SET, CLEAR, DONE, GIFT
		}

		public event Handler ActionWasTriggered;
		public ActionType Type;

		public Action(string identifier, string labelText, ActionType type, bool enabled = true) : base(identifier, labelText, enabled) {
			Type = type;
		}

		public void Trigger() {
			ActionWasTriggered?.Invoke(Identifier);
		}
	}
}
