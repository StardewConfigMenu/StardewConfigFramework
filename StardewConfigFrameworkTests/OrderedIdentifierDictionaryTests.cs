using System.Collections.Generic;
using NUnit.Framework;
using StardewConfigFramework;

namespace StardewConfigFrameworkTests {
	[TestFixture]
	public abstract class OrderedIdentifierDictionaryTests<T>: BaseTestClass where T : SCFObject {

		protected ISCFOrderedDictionary<T> OrdDic;
		protected List<T> Option;
		protected List<T> DupeOption;

		protected string ID(int index) {
			return Option[index].Identifier;
		}

		protected string DupeID(int index) {
			return DupeOption[index].Identifier;
		}

		protected string Label(int index) {
			return Option[index].Label;
		}

		protected string DupeLabel(int index) {
			return DupeOption[index].Label;
		}

		[Test]
		public void _TestFixtureContainsEnoughOptions() {
			var min = 5;
			Assert.Multiple(() => {
				Assert.IsTrue(((ICollection<T>) Option).Count >= min);
				Assert.IsTrue(((ICollection<T>) DupeOption).Count >= min);
			});
		}

		[Test]
		public void AddingDuplicatesThrowsError() {
			OrdDic.Add(Option[0]);
			Assert.Multiple(() => {
				Assert.Catch(() => OrdDic.Add(DupeOption[0]));
				Assert.Catch(() => OrdDic.Insert(0, DupeOption[0]));
			});
		}

		[Test]
		public void AddingAndRetrieving() {

			OrdDic.Add(Option[0]);
			OrdDic.Add(Option[1]);
			OrdDic.Add(Option[2]);
			OrdDic.Insert(2, Option[3]);

			Assert.Multiple(() => {
				Assert.AreEqual(OrdDic[ID(0)].Label, Label(0));
				Assert.AreEqual(OrdDic[ID(1)].Label, Label(1));
				Assert.AreEqual(OrdDic[ID(2)].Label, Label(2));
				Assert.AreEqual(OrdDic[2].Label, Label(3));
				Assert.AreEqual(((ICollection<T>) OrdDic).Count, 4);
				Assert.IsNull(OrdDic[ID(4)]);
				Assert.Catch(() => {
					var invalid = OrdDic[4];
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
				Assert.AreEqual(OrdDic[0].Identifier, ID(0));
				Assert.AreEqual(OrdDic[1].Identifier, ID(3));
				Assert.AreEqual(OrdDic[2].Identifier, ID(2));
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

		[Test]
		public void BadModifyInterfaceMethodsThrowsError() {
			OrdDic.Add(Option[0]);
			Assert.Multiple(() => {
				Assert.Catch(() => OrdDic.Add(ID(0), Option[1]));
				Assert.Catch(() => OrdDic.Add(ID(2), Option[1]));
				Assert.Catch(() => OrdDic.Add(new KeyValuePair<string, T>(ID(0), Option[1])));
				Assert.Catch(() => OrdDic.Add(new KeyValuePair<string, T>(ID(2), Option[1])));
			});

		}

		[Test]
		public void ForEach() {

			OrdDic.Add(new List<T> {
				Option[0],
				Option[1],
				Option[2],
				Option[3]
			});

			var index = 0;
			Assert.Multiple(() => {
				foreach (T option in OrdDic) {
					Assert.AreEqual(option.Identifier, "option" + index.ToString());
					index++;
				}
			});

		}
	}
}
