using System;
namespace StardewConfigFramework {
	public interface IConfigOption: SCFObject {
		bool Enabled { get; set; }
		new string Label { get; set; }
	}
}
