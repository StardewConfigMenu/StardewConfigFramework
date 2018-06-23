using StardewModdingAPI;
using System.Collections.Generic;

namespace StardewConfigFramework {
	public interface IModOptions {
		IManifest ModManifest { get; }
		IList<ModOptionsTab> Tabs { get; }
		int TabCount { get; }
	}
}
