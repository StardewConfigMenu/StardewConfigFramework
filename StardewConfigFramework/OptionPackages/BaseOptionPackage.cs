using System.Collections;
using System.Collections.Generic;
using StardewModdingAPI;

namespace StardewConfigFramework {
	public abstract class BaseOptionPackage: IOptionsPackage {
		protected BaseOptionPackage(IMod mod) {
			ModManifest = mod.ModManifest;
		}

		public IManifest ModManifest { get; private set; }

		private IList<IOptionsTab> _Tabs = new List<IOptionsTab>();
		public IList<IOptionsTab> Tabs => _Tabs;
	}
}
