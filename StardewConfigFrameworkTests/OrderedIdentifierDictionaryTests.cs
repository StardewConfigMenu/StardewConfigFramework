using NUnit.Framework;
using StardewConfigFramework.Options;
using System;
using System.Collections.Generic;

namespace StardewConfigFramework {
	[TestFixture]
	public abstract class OrderIdentifierDictionaryTests<T> where T : SCFObject {

		protected ISCFOrderedDictionary<T> OrdDic;
		protected List<T> Option;
		protected List<T> DupeOption;

		[SetUp]
		public void SetUp() {
			//OrdDic = new OptionsTab("Tab Name");
			// Should be done in derived class
		}

		[TearDown]
		public void TearDown() {
			//OrdDic = null;
			// Should be done in derived class
		}

		[Test]
		public void AddingDuplicatesThrowsError() {
			OrdDic.Add(Option[0]);
			Assert.Catch(() => OrdDic.Add(DupeOption[0]));
		}

		[Test]
		public void AddingAndRetrieving() {

			OrdDic.Add(Option[0]);
			OrdDic.Add(Option[1]);
			OrdDic.Add(Option[2]);

			Assert.Multiple(() => {
				Assert.AreEqual(OrdDic["Option[0]"].Label, "Option 1");
				Assert.AreEqual(OrdDic["Option[1]"].Label, "Option 2");
				Assert.AreEqual(OrdDic["Option[2]"].Label, "Option 3");
				Assert.AreEqual(((ICollection<T>) OrdDic).Count, 3);
				Assert.IsNull(OrdDic["Option[3]"]);
				Assert.Catch(() => {
					var invalid = OrdDic[3];
				});
			});
		}

		[Test]
		public void SubscriptSetting() {
			OrdDic.Add(Option[0]);
			OrdDic.Add(Option[1]);
			OrdDic.Add(Option[2]);

			OrdDic[1] = Option[3];

			Assert.Multiple(() => {
				Assert.AreEqual(OrdDic[0].Identifier, "Option[0]");
				Assert.AreEqual(OrdDic[1].Identifier, "Option[3]");
				Assert.AreEqual(OrdDic[2].Identifier, "Option[2]");
				Assert.AreEqual(((ICollection<T>) OrdDic).Count, 3);
			});
		}

		[Test]
		public void SubscriptSettingDuplicateError() {

			OrdDic.Add(Option[0]);
			OrdDic.Add(Option[1]);
			OrdDic.Add(Option[2]);

			Assert.Catch(() => OrdDic[1] = DupeOption[2]);
		}
	}
}
