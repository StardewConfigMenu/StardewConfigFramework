using System;

namespace StardewConfigFramework.Options {
	public class Range: ModOption {
		public delegate void Handler(Range range, decimal currentValue);

		public event Handler ValueDidChange;
		readonly public bool ShowValue;
		readonly public decimal StepSize;
		readonly public decimal Max;
		readonly public decimal Min;

		public Range(string identifier, string label, decimal min, decimal max, decimal stepSize, decimal defaultSelection, bool showValue, bool enabled = true) : base(identifier, label, enabled) {
			ShowValue = showValue;
			StepSize = Math.Round(stepSize, 3);
			Min = Math.Round(min, 3);
			Max = Math.Round(max, 3);
			Value = Math.Round(defaultSelection, 3);
		}

		private decimal _value;
		public decimal Value {
			get {
				return _value;
			}
			set {
				var input = GetValidInput(Math.Round(value, 3));
				int stepsAboveMin = (int) ((input - Min) / StepSize);
				var newVal = (stepsAboveMin * StepSize) + Min;
				if (newVal == _value)
					return;
				_value = newVal;
				ValueDidChange?.Invoke(this, _value);
			}
		}

		private decimal GetValidInput(decimal input) {
			if (input > Max)
				return Max;

			if (input < Min)
				return Min;

			return input;
		}
	}
}
