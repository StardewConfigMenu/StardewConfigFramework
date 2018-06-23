using System;
using System.Collections.Generic;
using StardewConfigFramework.Options;
using StardewModdingAPI;

namespace StardewConfigFramework {
	public class TabbedOptionsPackage: IOptionsPackage {
		public TabbedOptionsPackage(Mod mod) {
			ModManifest = mod.ModManifest;
		}

		public IManifest ModManifest { get; }
		public IList<OptionsTab> Tabs => _Tabs;
		private List<OptionsTab> _Tabs = new List<OptionsTab>();
		public int TabCount => _Tabs.Count;
	}
}
