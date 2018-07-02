using System.Collections.Generic;
using NUnit.Framework;
using StardewConfigFramework;
using StardewConfigFramework.Options;

namespace StardewConfigFrameworkTests {
	[TestFixture]
	public class OptionTabTests: OrderedIdentifierDictionaryTests<IConfigOption> {

		private OptionsTab Tab => (OptionsTab) OrdDic;

		[SetUp]
		public void SetUp() {
			OrdDic = new OptionsTab("tabID", "Tab Name").Options;
			Option = new List<IConfigOption> {
				new ConfigHeader("option0", "Option 0"),
				new ConfigHeader("option1", "Option 1"),
				new ConfigHeader("option2", "Option 2"),
				new ConfigHeader("option3", "Option 3"),
				new ConfigHeader("option4", "Option 4")
			};

			DupeOption = new List<IConfigOption> {
				new ConfigHeader("option0", "Dupe Option 0"),
				new ConfigHeader("option1", "Dupe Option 1"),
				new ConfigHeader("option2", "Dupe Option 2"),
				new ConfigHeader("option3", "Dupe Option 3"),
				new ConfigHeader("option4", "Dupe Option 4")
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
