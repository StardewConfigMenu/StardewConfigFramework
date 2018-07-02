using System;
using StardewConfigFramework.Options;

namespace StardewConfigFramework {
	public abstract class QuantizedRange: ConfigOption, IQuantizedRange {

		protected QuantizedRange(string identifier, string label, decimal min, decimal max, decimal stepSize, RangeDisplayType type = RangeDisplayType.DEFAULT, bool enabled = true) : base(identifier, label, enabled) {
			StepSize = Math.Round(stepSize, 3);
			Min = Math.Round(min, 3);
			Max = Math.Round(max, 3);
			DisplayType = type;
		}

		public RangeDisplayType DisplayType { get; }
		public decimal StepSize { get; }
		public decimal Max { get; }
		public decimal Min { get; }

		protected decimal GetValidInput(decimal input) {
			var rounded = Math.Round(input, 3);
			if (rounded > Max)
				return Max;

			if (rounded < Min)
				return Min;

			int stepsAboveMin = (int) ((rounded - Min) / StepSize);
			return (stepsAboveMin * StepSize) + Min;
		}
	}
}
