using System;
using System.Collections.Generic;
using StardewModdingAPI;

namespace StardewConfigFrameworkTests {
	public class TestMod: IMod {
		public TestMod() { }
		public TestMod(string id) {
			manifest = new TestManifest(id);
		}

		public IModHelper Helper => throw new NotImplementedException();

		public IMonitor Monitor => throw new NotImplementedException();

		public IManifest ModManifest => manifest;
		private TestManifest manifest = new TestManifest();

		public void Entry(IModHelper helper) {
			throw new NotImplementedException();
		}

		public object GetApi() {
			throw new NotImplementedException();
		}
	}

	public class TestManifest: IManifest {
		public TestManifest() { }
		public TestManifest(string id) {
			uniqueID = id;
		}

		private string uniqueID = "Test.Mod";

		public string Name => uniqueID;

		public string Description => throw new NotImplementedException();

		public string Author => throw new NotImplementedException();

		public ISemanticVersion Version => throw new NotImplementedException();

		public ISemanticVersion MinimumApiVersion => throw new NotImplementedException();

		public string UniqueID => uniqueID;

		public string EntryDll => throw new NotImplementedException();

		public IManifestContentPackFor ContentPackFor => throw new NotImplementedException();

		public IManifestDependency[] Dependencies => throw new NotImplementedException();

		public string[] UpdateKeys => throw new NotImplementedException();

		public IDictionary<string, object> ExtraFields => throw new NotImplementedException();
	}
}
