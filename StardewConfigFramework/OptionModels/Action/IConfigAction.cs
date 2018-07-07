using System;
namespace StardewConfigFramework.Options {
	public interface IConfigAction: IConfigOption {
		event ActionHandler ActionWasTriggered;
		ButtonType ButtonType { get; set; }
		void Trigger();
	}

	public delegate void ActionHandler(IConfigAction action);

	public enum ButtonType {
		OK, SET, CLEAR, DONE, GIFT
	}
}
