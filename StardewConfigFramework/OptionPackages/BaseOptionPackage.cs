using System.Collections;
using System.Collections.Generic;
using StardewModdingAPI;

namespace StardewConfigFramework {
	public abstract class BaseOptionPackage: IOptionsPackage {
		protected BaseOptionPackage(IMod mod) {
			ModManifest = mod.ModManifest;
		}

		public IManifest ModManifest { get; private set; }

		private IOrderedDictionary<IOptionsTab> _Tabs = new OrderedDictionary<IOptionsTab>();
		public IOrderedDictionary<IOptionsTab> Tabs => _Tabs;
	}
}
