using System;
using StardewConfigFramework.Options;

namespace StardewConfigFramework {
	public abstract class QuantizedRange: ModOption, IQuantizedRange {

		protected QuantizedRange(string identifier, string label, decimal min, decimal max, decimal stepSize, bool enabled = true) : base(identifier, label, enabled) {
			StepSize = Math.Round(stepSize, 3);
			Min = Math.Round(min, 3);
			Max = Math.Round(max, 3);
		}

		public decimal StepSize { get; }
		public decimal Max { get; }
		public decimal Min { get; }

		protected decimal GetValidInput(decimal input) {
			if (input > Max)
				return Max;

			if (input < Min)
				return Min;

			int stepsAboveMin = (int) ((input - Min) / StepSize);
			return (stepsAboveMin * StepSize) + Min;
		}
	}
}
