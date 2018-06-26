using System;
using StardewConfigFramework;

namespace StardewConfigFrameworkTests {
	public class TestConfigMenu: IConfigMenu {

		public IOptionsPackage Package;

		public override void AddOptionsPackage(IOptionsPackage package) {
			Package = package;
		}
	}
}
