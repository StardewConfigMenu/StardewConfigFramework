using System.Collections;
using System.Collections.Generic;
using StardewModdingAPI;

namespace StardewConfigFramework {
	public abstract class BaseOptionPackage: IOptionsPackage {
		protected BaseOptionPackage(IMod mod) {
			ModManifest = mod.ModManifest;
		}

		public IManifest ModManifest { get; private set; }

		public List<OptionsTab> Tabs { get; } = new List<OptionsTab>();
	}
}
