using System.Collections.Generic;
using NUnit.Framework;
using StardewConfigFramework;
using StardewConfigFramework.Options;

namespace StardewConfigFrameworkTests {
	[TestFixture()]
	public class SelectionTests: OrderedIdentifierDictionaryTests<ISelectionChoice> {

		private Selection Selection;

		[SetUp]
		public void SetUp() {
			Selection = new Selection("testSelection", "Test Selection");
			OrdDic = Selection.Choices;
			Option = new List<ISelectionChoice> {
				new SelectionChoice("option0", "Option 0"),
				new SelectionChoice("option1", "Option 1"),
				new SelectionChoice("option2", "Option 2"),
				new SelectionChoice("option3", "Option 3"),
				new SelectionChoice("option4", "Option 4")
			};

			DupeOption = new List<ISelectionChoice> {
				new SelectionChoice("option0", "Dupe Option 0"),
				new SelectionChoice("option1", "Dupe Option 1"),
				new SelectionChoice("option2", "Dupe Option 2"),
				new SelectionChoice("option3", "Dupe Option 3"),
				new SelectionChoice("option4", "Dupe Option 4")
			};
		}

		[TearDown]
		public void TearDown() {
			Selection = null;
			OrdDic = null;
			Option = null;
			DupeOption = null;
		}

		[Test]
		public void EmptyInit() {

			var selection = new Selection("test", "Test");

			Assert.Multiple(() => {
				Assert.AreEqual(selection.SelectedIndex, 0);
				Assert.AreEqual(selection.SelectedChoice, null);
				Assert.AreEqual(selection.SelectedIdentifier, null);
			});
		}

		[Test]
		public void AddToEmpty() {

			var selection = new Selection("test", "Test");

			selection.Choices.Add(Option[0]);

			Assert.Multiple(() => {
				Assert.AreEqual(selection.SelectedIndex, 0);
				Assert.AreEqual(selection.SelectedChoice, Option[0]);
				Assert.AreEqual(selection.SelectedIdentifier, Option[0].Identifier);
			});
		}

		[Test]
		public void SetInvalidSelected() {

			var choices = new List<ISelectionChoice> {
				Option[0],
				Option[1],
				Option[2]
			};

			var selection = new Selection("test", "Test", choices);
			var eventDidFire = false;
			selection.SelectionDidChange += (option) => {
				eventDidFire = true;
			};

			Assert.Multiple(() => {
				Assert.Catch(() => {
					selection.SelectedIndex = 3;
				});

				Assert.Catch(() => {
					selection.SelectedIdentifier = "invalid";
				});

				Assert.IsFalse(eventDidFire);
			});
		}

		[Test]
		public void InitDefaultSelection() {

			var choices = new List<ISelectionChoice> {
				Option[0],
				Option[1],
				Option[2]
			};

			var selection = new Selection("test", "Test", choices, 2);

			Assert.Multiple(() => {
				Assert.AreEqual(selection.SelectedChoice, Option[2]);
				Assert.AreEqual(selection.SelectedIndex, 2);
				Assert.AreEqual(selection.SelectedIdentifier, Option[2].Identifier);
			});
		}

		[Test]
		public void EventDoesFireOnChange() {

			var choices = new List<ISelectionChoice> {
				Option[0],
				Option[1],
				Option[2]
			};

			Selection.Choices.Add(choices);
			var eventDidFire = false;
			Selection.SelectionDidChange += (option) => {
				eventDidFire = true;
			};

			Selection.SelectedIndex = 1;

			Assert.Multiple(() => {
				Assert.IsTrue(eventDidFire);
			});
		}

		[Test]
		public void EventDoesNotFireOnNoChange() {

			var choices = new List<ISelectionChoice> {
				Option[0],
				Option[1],
				Option[2]
			};

			Selection.Choices.Add(choices);
			var eventDidFire = false;
			Selection.SelectionDidChange += (option) => {
				eventDidFire = true;
			};

			Selection.SelectedIndex = 0;
			Selection.SelectedIdentifier = ID(0);

			Assert.Multiple(() => {
				Assert.IsFalse(eventDidFire);
			});
		}
	}
}
