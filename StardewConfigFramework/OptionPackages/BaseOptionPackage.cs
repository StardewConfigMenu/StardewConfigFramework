using System.Collections;
using System.Collections.Generic;
using StardewModdingAPI;

namespace StardewConfigFramework {
	public abstract class BaseOptionPackage: IOptionsPackage {
		protected BaseOptionPackage(IMod mod) {
			ModManifest = mod.ModManifest;
		}

		public IManifest ModManifest { get; private set; }

		private ISCFOrderedDictionary<IOptionsTab> _Tabs = new SCFOrderedDictionary<IOptionsTab>();
		public ISCFOrderedDictionary<IOptionsTab> Tabs => _Tabs;
	}
}
