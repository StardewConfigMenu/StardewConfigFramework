using System;
using NUnit.Framework;
using StardewConfigFramework;
using StardewConfigFramework.Options;

namespace StardewConfigFrameworkTests {
	[TestFixture]
	public class PackageTests: BaseTestClass {

		[Test]
		public void SimplePackageInitialization() {

			var package = new SimpleOptionsPackage(Mod);

			Assert.Multiple(() => {
				Assert.AreEqual(package.Tabs.Count, 1);
				Assert.AreEqual(package.Tabs[0].Options.Count, 0);
			});
		}

		[Test]
		public void TabbedPackageInitialization() {

			var package = new TabbedOptionsPackage(Mod);

			Assert.AreEqual(package.Tabs.Count, 0);
		}

		[Test]
		public void SimplePackageAddOption() {

			var package = new SimpleOptionsPackage(Mod);
			var optionID = "label";
			package.AddOption(new ConfigHeader(optionID, "Title"));

			Assert.Multiple(() => {
				Assert.AreEqual(package.Tabs.Count, 1); // still only 1 tab
				Assert.AreEqual(package.Tabs[0].Options.Count, 1);
				Assert.IsInstanceOf<ConfigHeader>(package.GetOption<ConfigHeader>(optionID));
				Assert.True(package.ContainsOption(optionID));
				Assert.AreEqual(package.IndexOfOption(optionID), 0);
				Assert.True(package.RemoveOption(optionID));
				Assert.False(package.ContainsOption(optionID));
				Assert.Null(package.GetOption<ConfigHeader>(optionID));
			});
		}

		[Test]
		public void TabbedPackageMultipleTabs() {

			var package = new TabbedOptionsPackage(Mod);
			var tab1 = new OptionsTab("label1", "Label1");
			var tab2 = new OptionsTab("label2", "Label2");
			var tab3 = new OptionsTab("label3", "Label3");

			Assert.Multiple(() => {
				Assert.IsEmpty(package.Tabs);
				package.Tabs.Add(tab1);
				Assert.AreEqual(package.Tabs.Count, 1);
				package.Tabs.Add(tab2);
				Assert.AreEqual(package.Tabs.Count, 2);
				package.Tabs.Add(tab1);
				Assert.AreEqual(package.Tabs.Count, 3);
				Assert.AreEqual(package.Tabs[2].Label, "Label1");
				package.Tabs.Insert(0, tab3);
				Assert.AreEqual(package.Tabs.Count, 4);
				Assert.AreEqual(package.Tabs[0].Label, "Label3");
				Assert.AreEqual(package.Tabs[3].Label, "Label1");
				package.Tabs.RemoveAt(1);
				Assert.AreEqual(package.Tabs.Count, 3);
				Assert.AreEqual(package.Tabs.IndexOf(tab1), 2);
			});
		}
	}
}
