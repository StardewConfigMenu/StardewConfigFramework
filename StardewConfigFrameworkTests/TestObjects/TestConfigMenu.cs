using System;
using System.Collections.Generic;
using StardewConfigFramework;

namespace StardewConfigFrameworkTests {
	public class TestConfigMenu: IConfigMenu {

		public List<IOptionsPackage> PackageList = new List<IOptionsPackage>();

		public void AddOptionsPackage(IOptionsPackage package) {
			PackageList.Add(package);
		}
	}
}
