using System;
namespace StardewConfigFramework.Options {
	public interface IAction {
		event Handler ActionWasTriggered;
		ActionType Type { get; set; }
		void Trigger();
	}

	public delegate void Handler(Action action);

	public enum ActionType {
		OK, SET, CLEAR, DONE, GIFT
	}
}
