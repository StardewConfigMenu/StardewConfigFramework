using System;
using System.Collections.Generic;
using StardewConfigFramework.Options;
using StardewModdingAPI;

namespace StardewConfigFramework {
	public class TabbedModOptions: IModOptions {
		public TabbedModOptions(Mod mod) {
			this.ModManifest = mod.ModManifest;
		}

		public IManifest ModManifest { get; }
		public IList<ModOptionsTab> Tabs => _Tabs;
		private List<ModOptionsTab> _Tabs = new List<ModOptionsTab>();
		public int TabCount => _Tabs.Count;
	}
}
