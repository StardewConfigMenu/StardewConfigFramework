
namespace StardewConfigFramework.Options {
	public abstract class ModOption: SCFObject {
		public string Identifier { get; }
		public string Label { get; set; }
		public bool Enabled { get; set; }

		protected ModOption(string identifier, string label, bool enabled = true) {
			Identifier = identifier;
			Label = label;
			Enabled = enabled;
		}
	}
}
