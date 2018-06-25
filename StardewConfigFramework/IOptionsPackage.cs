using StardewModdingAPI;
using System.Collections.Generic;

namespace StardewConfigFramework {
	public interface IOptionsPackage {
		IManifest ModManifest { get; }
		IList<OptionsTab> Tabs { get; }
	}
}
