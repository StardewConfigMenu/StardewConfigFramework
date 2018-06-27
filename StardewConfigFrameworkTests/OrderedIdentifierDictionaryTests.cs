using System.Collections.Generic;
using NUnit.Framework;
using StardewConfigFramework;

namespace StardewConfigFrameworkTests {
	[TestFixture]
	public abstract class OrderedIdentifierDictionaryTests<T>: BaseTestClass where T : SCFObject {

		protected ISCFOrderedDictionary<T> OrdDic;
		protected List<T> Option;
		protected List<T> DupeOption;

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
				Assert.AreEqual(OrdDic["option0"].Label, "Option 0");
				Assert.AreEqual(OrdDic["option1"].Label, "Option 1");
				Assert.AreEqual(OrdDic["option2"].Label, "Option 2");
				Assert.AreEqual(((ICollection<T>) OrdDic).Count, 3);
				Assert.IsNull(OrdDic["option3"]);
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
				Assert.AreEqual(OrdDic[0].Identifier, "option0");
				Assert.AreEqual(OrdDic[1].Identifier, "option3");
				Assert.AreEqual(OrdDic[2].Identifier, "option2");
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
