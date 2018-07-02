using System;

namespace StardewConfigFramework.Options {
	public class ConfigStepper: QuantizedRange, IConfigStepper {

		public event StepperHandler ValueDidChange;

		public ConfigStepper(string identifier, string labelText, decimal min, decimal max, decimal stepSize, decimal defaultValue, RangeDisplayType type = RangeDisplayType.DEFAULT, bool enabled = true) : base(identifier, labelText, min, max, stepSize, type, enabled) {
			_Value = GetValidInput(defaultValue);
		}

		protected decimal _Value;
		public decimal Value {
			get => _Value;
			set {
				var valid = GetValidInput(value);
				if (valid == _Value)
					return;
				_Value = valid;
				ValueDidChange?.Invoke(this);
			}
		}

		public void StepUp() {
			if (!CanStepUp())
				return;

			Value += StepSize;
		}

		public void StepDown() {
			if (!CanStepDown())
				return;

			Value -= StepSize;
		}

		public bool CanStepUp() {
			return Value + StepSize <= Max;
		}

		public bool CanStepDown() {
			return Value - StepSize >= Min;
		}
	}
}
