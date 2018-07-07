using System;
namespace StardewConfigFramework.Options {
	public interface IConfigStepper: IQuantizedRange {
		event StepperHandler ValueDidChange;
		decimal Value { get; set; }
		void StepUp();
		void StepDown();
		bool CanStepUp { get; }
		bool CanStepDown { get; }
	}

	public delegate void StepperHandler(IConfigStepper stepper);
}
