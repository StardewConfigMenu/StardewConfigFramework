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
				Assert.AreEqual(package.Count, 1);
				Assert.AreEqual(package[0].Count, 0);
			});
		}

		[Test]
		public void TabbedPackageInitialization() {

			var package = new TabbedOptionsPackage(Mod);

			Assert.AreEqual(package.Count, 0);
		}

		[Test]
		public void SimplePackageAddOption() {

			var package = new SimpleOptionsPackage(Mod);
			var optionID = "label";
			package.AddOption(new CategoryLabel(optionID, "Title"));

			Assert.Multiple(() => {
				Assert.AreEqual(package.Count, 1); // still only 1 tab
				Assert.AreEqual(package[0].Count, 1);
				Assert.IsInstanceOf<CategoryLabel>(package.GetOption<CategoryLabel>(optionID));
				Assert.True(package.ContainsOption(optionID));
				Assert.AreEqual(package.IndexOfOption(optionID), 0);
				Assert.True(package.RemoveOption(optionID));
				Assert.False(package.ContainsOption(optionID));
				Assert.Null(package.GetOption<CategoryLabel>(optionID));
			});
		}
	}
}
