using System;

namespace StardewConfigFramework.Options {
	public class Stepper: QuantizedRange {
		public delegate void Handler(Stepper stepper);

		public event Handler ValueDidChange;
		readonly public DisplayType Type;

		public Stepper(string identifier, string labelText, decimal min, decimal max, decimal stepSize, decimal defaultValue, DisplayType type = DisplayType.NONE, bool enabled = true) : base(identifier, labelText, min, max, stepSize, enabled) {
			Type = type;
			_Value = GetValidInput(Math.Round(defaultValue, 3));
		}

		protected decimal _Value;
		public decimal Value {
			get => _Value;
			set {
				var valid = GetValidInput(Math.Round(value, 3));
				if (valid == _Value)
					return;
				_Value = valid;
				ValueDidChange?.Invoke(this);
			}
		}

		public void StepUp() {
			Value = Value + StepSize;
		}

		public void StepDown() {
			Value = Value - StepSize;
		}
	}
}
