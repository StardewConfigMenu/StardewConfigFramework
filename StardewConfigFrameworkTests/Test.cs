using System;
using NUnit.Framework;
using StardewConfigFramework;

namespace StardewConfigFrameworkTests {
	[TestFixture]
	public class PackageTests {

		private IConfigMenu menu;
		private TestMod mod;

		[SetUp]
		public void SetUp() {
			menu = new TestConfigMenu();
			mod = new TestMod();
		}

		[TearDown]
		public void TearDown() {
			menu = null;
			mod = null;
		}

		[Test]
		public void SimplePackageHasTab() {

			var package = new SimpleOptionsPackage(mod);

			Assert.Multiple(() => {
				Assert.AreEqual(package.Count, 1);
				Assert.AreEqual(package[0].Count, 0);
			});
		}
	}
}
