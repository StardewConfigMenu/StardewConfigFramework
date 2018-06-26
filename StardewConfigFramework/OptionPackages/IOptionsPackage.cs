using System.Collections.Generic;
using StardewModdingAPI;

namespace StardewConfigFramework {
	public interface IOptionsPackage: IList<OptionsTab> {
		IManifest ModManifest { get; }
	}
}
