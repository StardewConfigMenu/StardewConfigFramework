using System;

namespace StardewConfigFramework.Options {
	public class ConfigRange: QuantizedRange, IConfigRange {

		public event RangeHandler ValueDidChange;
		public bool ShowValue { get; }

		public ConfigRange(string identifier, string label, decimal min, decimal max, decimal stepSize, decimal defaultValue, bool showValue, RangeDisplayType type = RangeDisplayType.DEFAULT, bool enabled = true) : base(identifier, label, min, max, stepSize, type, enabled) {
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
