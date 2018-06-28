using System;

namespace StardewConfigFramework.Options {
	public class Range: QuantizedRange {
		public delegate void Handler(Range range);

		public event Handler ValueDidChange;
		readonly public bool ShowValue;

		public Range(string identifier, string label, decimal min, decimal max, decimal stepSize, decimal defaultValue, bool showValue, bool enabled = true) : base(identifier, label, min, max, stepSize, enabled) {
			ShowValue = showValue;
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
	}
}
