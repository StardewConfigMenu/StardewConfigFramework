using System;
namespace StardewConfigFramework.Options {
	public interface IConfigStepper: IQuantizedRange {
		event StepperHandler ValueDidChange;
		decimal Value { get; set; }
		void StepUp();
		void StepDown();
	}

	public delegate void StepperHandler(IConfigStepper stepper);
}
