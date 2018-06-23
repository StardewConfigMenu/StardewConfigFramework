using StardewModdingAPI;
using StardewConfigFramework.Options;
using System.Collections.Generic;
using System;

namespace StardewConfigFramework {
	public interface IModOptions {
		IManifest ModManifest { get; }
		IList<ModOptionsTab> Tabs { get; }
		int TabCount { get; }
	}
}
