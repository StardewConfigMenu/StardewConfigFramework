using StardewModdingAPI;
using StardewConfigFramework.Options;
using System.Collections.Generic;
using System;

namespace StardewConfigFramework {
	public interface IModOptions {
		IManifest ModManifest { get; }
		int TabCount { get; }
		IList<ModOption> GetOptionListForTab(int optionIndex);
	}
}
