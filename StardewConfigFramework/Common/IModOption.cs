using System;
namespace StardewConfigFramework {
	public interface IModOption: SCFObject {
		bool Enabled { get; set; }
		new string Label { get; set; }
	}
}
