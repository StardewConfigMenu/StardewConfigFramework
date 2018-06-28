using System;
using StardewConfigFramework.Options;

namespace StardewConfigFramework.Options {
	public interface IRange: IQuantizedRange {
		event RangeHandler ValueDidChange;
		bool ShowValue { get; }
		decimal Value { get; set; }
	}

	public delegate void RangeHandler(Range range);

}
