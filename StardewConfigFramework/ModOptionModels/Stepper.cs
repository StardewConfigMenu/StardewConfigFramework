using System;

namespace StardewConfigFramework.Options {

	public class Stepper: ModOption {
		public delegate void Handler(string identifier, decimal currentValue);
		public enum DisplayType {
			NONE, PERCENT
		}

		public event Handler ValueDidChange;
		readonly public DisplayType Type;
		readonly public decimal StepSize;
		readonly public decimal Max;
		readonly public decimal Min;

		public Stepper(string identifier, string labelText, decimal min, decimal max, decimal stepsize, decimal defaultValue, DisplayType type = Type.NONE, bool enabled = true) : base(identifier, labelText, enabled) {
			this.Min = Math.Round(min, 3);
			this.Max = Math.Round(max, 3);
			this.StepSize = Math.Round(stepsize, 3);
			this.Type = type;

			var valid = CheckValidInput(Math.Round(defaultValue, 3));
			this.Value = valid - ((valid - min) % StepSize);
		}

		private decimal _Value;
		public decimal Value {

			get {
				return _Value;
			}

			set {
				var valid = CheckValidInput(Math.Round(value, 3));
				var newVal = (int) ((valid - Min) / StepSize) * StepSize + Min;
				if (newVal == this._Value)
					return;
				this._Value = newVal;
				this.ValueDidChange?.Invoke(this.Identifier, this._Value);
			}
		}


		public void StepUp() {
			this.Value = this.Value + this.StepSize;
		}

		public void StepDown() {
			this.Value = this.Value - this.StepSize;
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
