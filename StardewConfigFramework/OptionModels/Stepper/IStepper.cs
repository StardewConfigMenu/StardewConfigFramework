using System;
namespace StardewConfigFramework.Options {
	public interface IStepper: IQuantizedRange {
		event StepperHandler ValueDidChange;
		decimal Value { get; set; }
		void StepUp();
		void StepDown();
	}

	public delegate void StepperHandler(Stepper stepper);
}
