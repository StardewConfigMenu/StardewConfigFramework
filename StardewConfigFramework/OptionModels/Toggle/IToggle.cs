using System;
namespace StardewConfigFramework.Options {
	public interface IToggle: IModOption {
		event ToggleHandler StateDidChange;
		bool IsOn { get; set; }
		void Flip();
	}

	public delegate void ToggleHandler(Toggle toggle);
}
