using NUnit.Framework;
using StardewConfigFramework;
using StardewConfigFramework.Options;
using System;
using System.Collections.Generic;

namespace StardewConfigFrameworkTests {
	[TestFixture()]
	public class MenuStories: BaseTestClass {

		IConfigMenu ConfigMenu => Menu;

		[Test]
		public void TestFullMenu() {
			var testPackage = new TabbedOptionsPackage(Mod);
			Menu.AddOptionsPackage(testPackage);

			Console.Write("package added\n");

			var testTab = new OptionsTab("Tab1");

			var testOptions = new List<IConfigOption> {
				new ConfigHeader("option0", "Option 0"),
				new ConfigSelection("option1", "Option 1"),
				new ConfigAction("option2", "Option 2", ButtonType.OK),
				new ConfigToggle("option3", "Option 3"),
				new ConfigStepper("option4", "Option 4", 0, 10, 1, 0),
				new ConfigRange("option5", "Option 5", 0, 10, 1, 0, false)
			};

			testTab.Options.Add(testOptions);
			testPackage.Tabs.Add(testTab);

			var packageList = Menu.PackageList;

			foreach (IOptionsPackage package in packageList) {
				if (package.Tabs.Count == 0)
					continue;

				var tab = package.Tabs[0];

				Assert.Multiple(() => {
					Assert.Greater(tab.Options.Count, 0);

					foreach (ConfigOption option in tab.Options) {
						Type t = option.GetType();
						Assert.IsNotNull(t);

						if (t.Equals(typeof(ConfigHeader)))
							Assert.AreEqual(option.Identifier, "option0");
						else if (t.Equals(typeof(ConfigSelection))) {
							Assert.AreEqual(option.Identifier, "option1");
						} else if (t.Equals(typeof(ConfigToggle)))
							Assert.AreEqual(option.Identifier, "option3");
						else if (t.Equals(typeof(ConfigAction)))
							Assert.AreEqual(option.Identifier, "option2");
						else if (t.Equals(typeof(ConfigStepper)))
							Assert.AreEqual(option.Identifier, "option4");
						else if (t.Equals(typeof(ConfigRange)))
							Assert.AreEqual(option.Identifier, "option5");
					}
				});
			}
		}
	}
}
