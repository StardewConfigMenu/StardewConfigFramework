using System;
using System.Collections.Generic;
using StardewModdingAPI;

namespace StardewConfigFrameworkTests {
	public class TestMod: IMod {

		public IModHelper Helper => throw new NotImplementedException();

		public IMonitor Monitor => throw new NotImplementedException();

		public IManifest ModManifest => throw new NotImplementedException();

		public void Entry(IModHelper helper) {
			throw new NotImplementedException();
		}

		public object GetApi() {
			throw new NotImplementedException();
		}
	}
}
