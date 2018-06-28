using System;
namespace StardewConfigFramework {
	public interface IModOption: SCFObject {
		bool Enabled { get; set; }
	}
}
