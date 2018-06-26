using NUnit.Framework;
using System;
namespace StardewConfigFrameworkTests {
	[TestFixture()]
	public class BaseTestClass {

		protected TestConfigMenu Menu;
		protected TestMod Mod;

		[SetUp]
		public void SetUp() {
			Menu = new TestConfigMenu();
			Mod = new TestMod();
		}

		[TearDown]
		public void TearDown() {
			Menu = null;
			Mod = null;
		}
	}
}
