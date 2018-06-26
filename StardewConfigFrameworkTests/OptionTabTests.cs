﻿using NUnit.Framework;
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

		[Test]
		public void AddingAndRetrieving() {
			var option1 = new CategoryLabel("option1", "Option 1");
			var option2 = new CategoryLabel("option2", "Option 2");
			var option3 = new CategoryLabel("option3", "Option 3");

			Tab.Add(option1);
			Tab.Add(option2);
			Tab.Add(option3);

			Assert.AreEqual(Tab["option2"].Label, "Option 2");
		}

		[Test]
		public void SubscriptSetting() {
			var option1 = new CategoryLabel("option1", "Option 1");
			var option2 = new CategoryLabel("option2", "Option 2");
			var option3 = new CategoryLabel("option3", "Option 3");
			var option4 = new CategoryLabel("option4", "Option 4");

			Tab.Add(option1);
			Tab.Add(option2);
			Tab.Add(option3);

			Tab[1] = option4;

			Assert.AreEqual(Tab.IndexOf("option4"), 1);
		}

		[Test]
		public void SubscriptSettingDuplicateError() {
			var option1 = new CategoryLabel("option1", "Option 1");
			var option2 = new CategoryLabel("option2", "Option 2");
			var option3 = new CategoryLabel("option3", "Option 3");
			var option3dupe = new CategoryLabel("option3", "Option 3 Dupe");

			Tab.Add(option1);
			Tab.Add(option2);
			Tab.Add(option3);

			Assert.Catch(() => Tab[1] = option3dupe);
		}
	}
}
