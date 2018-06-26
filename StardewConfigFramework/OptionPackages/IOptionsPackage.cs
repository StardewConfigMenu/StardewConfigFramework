using StardewModdingAPI;
using System.Collections.Generic;

namespace StardewConfigFramework {
	public interface IOptionsPackage: IList<OptionsTab> {
		IManifest ModManifest { get; }
	}
}
