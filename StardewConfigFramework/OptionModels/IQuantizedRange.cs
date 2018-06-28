using System;
namespace StardewConfigFramework.Options {
	public interface IQuantizedRange: IModOption {
		decimal StepSize { get; }
		decimal Max { get; }
		decimal Min { get; }
	}

	public enum RangeDisplayType {
		DEFAULT, PERCENT
	}
}
