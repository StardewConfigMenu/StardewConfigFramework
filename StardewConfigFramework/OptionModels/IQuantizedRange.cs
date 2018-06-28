using System;
namespace StardewConfigFramework {
	public interface IQuantizedRange: IModOption {
		decimal StepSize { get; }
		decimal Max { get; }
		decimal Min { get; }
	}

	public enum RangeDisplayType {
		DEFAULT, PERCENT
	}
}
