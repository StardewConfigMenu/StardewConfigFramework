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

			var choices = new List<ModOption> {
				new CategoryLabel("option0", "Option 0"),
				new Selection("option1", "Option 1"),
				new StardewConfigFramework.Options.Action("option2", "Option 2", StardewConfigFramework.Options.Action.ActionType.OK),
				new Toggle("option3", "Option 3"),
				new Stepper("option4", "Option 4", 0, 10, 1, 0),
				new Range("option5", "Option 5", 0, 10, 1, 0, false)
			};

			testTab.Add(choices);
			testPackage.Add(testTab);

			var packageList = Menu.PackageList;

			foreach (IOptionsPackage package in packageList) {
				if (package.Count == 0)
					continue;

				var tab = package[0];

				Assert.Multiple(() => {
					Assert.Greater(tab.Count, 0);

					foreach (ModOption option in tab) {
						Type t = option.GetType();
						Assert.IsNotNull(t);

						if (t.Equals(typeof(CategoryLabel)))
							Assert.AreEqual(option.Identifier, "option0");
						else if (t.Equals(typeof(Selection))) {
							Assert.AreEqual(option.Identifier, "option1");
						} else if (t.Equals(typeof(Toggle)))
							Assert.AreEqual(option.Identifier, "option3");
						else if (t.Equals(typeof(StardewConfigFramework.Options.Action)))
							Assert.AreEqual(option.Identifier, "option2");
						else if (t.Equals(typeof(Stepper)))
							Assert.AreEqual(option.Identifier, "option4");
						else if (t.Equals(typeof(Range)))
							Assert.AreEqual(option.Identifier, "option5");
					}
				});
			}
		}
	}
}
