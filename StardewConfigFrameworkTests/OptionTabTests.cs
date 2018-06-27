using System.Collections.Generic;
using NUnit.Framework;
using StardewConfigFramework;
using StardewConfigFramework.Options;

namespace StardewConfigFrameworkTests {
	[TestFixture]
	public class OptionTabTests: OrderedIdentifierDictionaryTests<ModOption> {

		private OptionsTab Tab => (OptionsTab) OrdDic;

		[SetUp]
		public void SetUp() {
			OrdDic = new OptionsTab("Tab Name");
			Option = new List<ModOption> {
				new CategoryLabel("option0", "Option 0"),
				new CategoryLabel("option1", "Option 1"),
				new CategoryLabel("option2", "Option 2"),
				new CategoryLabel("option3", "Option 3")
			};

			DupeOption = new List<ModOption> {
				new CategoryLabel("option0", "Dupe Option 0"),
				new CategoryLabel("option1", "Dupe Option 1"),
				new CategoryLabel("option2", "Dupe Option 2"),
				new CategoryLabel("option3", "Dupe Option 3")
			};
		}

		[TearDown]
		public void TearDown() {
			OrdDic = null;
			Option = null;
			DupeOption = null;
		}
	}
}
