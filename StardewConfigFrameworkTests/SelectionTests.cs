using System.Collections.Generic;
using NUnit.Framework;
using StardewConfigFramework;
using StardewConfigFramework.Options;

namespace StardewConfigFrameworkTests {
	[TestFixture()]
	public class SelectionTests: OrderedIdentifierDictionaryTests<SelectionChoice> {

		private Selection Selection => (Selection) OrdDic;

		[SetUp]
		public void SetUp() {
			OrdDic = new Selection("testSelection", "Test Selection");
			Option = new List<SelectionChoice> {
				new SelectionChoice("option0", "Option 0"),
				new SelectionChoice("option1", "Option 1"),
				new SelectionChoice("option2", "Option 2"),
				new SelectionChoice("option3", "Option 3")
			};

			DupeOption = new List<SelectionChoice> {
				new SelectionChoice("option0", "Dupe Option 0"),
				new SelectionChoice("option1", "Dupe Option 1"),
				new SelectionChoice("option2", "Dupe Option 2"),
				new SelectionChoice("option3", "Dupe Option 3")
			};
		}

		[TearDown]
		public void TearDown() {
			OrdDic = null;
			Option = null;
			DupeOption = null;
		}

		[Test]
		public void SelectionInit() {

			var selection = new Selection("test", "Test");

			Assert.Multiple(() => {
				Assert.AreEqual(selection.SelectedIndex, 0);
				Assert.AreEqual(selection.SelectedChoice, null);
				Assert.AreEqual(selection.SelectedIdentifier, null);
			});
		}
	}
}
