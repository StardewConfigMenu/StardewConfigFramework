using System;
namespace StardewConfigFramework.Options {
	public interface IAction: IModOption {
		event ActionHandler ActionWasTriggered;
		ButtonType ButtonType { get; set; }
		void Trigger();
	}

	public delegate void ActionHandler(Action action);

	public enum ButtonType {
		OK, SET, CLEAR, DONE, GIFT
	}
}
