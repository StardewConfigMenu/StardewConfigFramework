using NUnit.Framework;
using StardewConfigFramework;
using StardewConfigFramework.Options;
using System;

namespace StardewConfigFrameworkTests {
	[TestFixture]
	public class OptionTabTests: BaseTestClass {

		private OptionsTab Tab;

		[SetUp]
		public void SetUp() {
			Tab = new OptionsTab("Tab Name");
		}

		[TearDown]
		public void TearDown() {
			Tab = null;
		}

		[Test]
		public void AddingDuplicatesThrowsError() {
			var option1 = new CategoryLabel("option1", "Option 1");
			var option1dupe = new CategoryLabel("option1", "Option 1 Dupe");

			Tab.Add(option1);

			Assert.Catch(() => Tab.Add(option1dupe));
		}
	}
}
