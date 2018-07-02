using System.Collections.Generic;
using StardewModdingAPI;

namespace StardewConfigFramework {
	public interface IOptionsPackage {
		IManifest ModManifest { get; }
		ISCFOrderedDictionary<IOptionsTab> Tabs { get; }
	}
}
