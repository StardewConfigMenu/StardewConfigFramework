using System;

namespace StardewConfigFramework.Options {
	public class Stepper: ModOption {
		public delegate void Handler(Stepper stepper);
		public enum DisplayType {
			NONE, PERCENT
		}

		public event Handler ValueDidChange;
		readonly public DisplayType Type;
		readonly public decimal StepSize;
		readonly public decimal Max;
		readonly public decimal Min;

		public Stepper(string identifier, string labelText, decimal min, decimal max, decimal stepsize, decimal defaultValue, DisplayType type = DisplayType.NONE, bool enabled = true) : base(identifier, labelText, enabled) {
			Min = Math.Round(min, 3);
			Max = Math.Round(max, 3);
			StepSize = Math.Round(stepsize, 3);
			Type = type;

			var valid = CheckValidInput(Math.Round(defaultValue, 3));
			Value = valid - ((valid - min) % StepSize);
		}

		private decimal _Value;
		public decimal Value {

			get {
				return _Value;
			}

			set {
				var valid = CheckValidInput(Math.Round(value, 3));
				var newVal = (int) ((valid - Min) / StepSize) * StepSize + Min;
				if (newVal == _Value)
					return;
				_Value = newVal;
				ValueDidChange?.Invoke(this);
			}
		}

		public void StepUp() {
			Value = Value + StepSize;
		}

		public void StepDown() {
			Value = Value - StepSize;
		}

		private decimal CheckValidInput(decimal input) {
			if (input > Max)
				return Max;

			if (input < Min)
				return Min;

			return input;
		}
	}
}
