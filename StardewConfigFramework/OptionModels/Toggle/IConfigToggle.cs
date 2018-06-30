using System;
namespace StardewConfigFramework.Options {
	public interface IConfigToggle: IConfigOption {
		event ToggleHandler StateDidChange;
		bool IsOn { get; set; }
		void Flip();
	}

	public delegate void ToggleHandler(IConfigToggle toggle);
}
