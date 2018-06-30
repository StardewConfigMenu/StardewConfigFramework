
namespace StardewConfigFramework.Options {
	public abstract class ConfigOption: IConfigOption {
		public string Identifier { get; }
		public string Label { get; set; }
		public bool Enabled { get; set; }

		protected ConfigOption(string identifier, string label, bool enabled = true) {
			Identifier = identifier;
			Label = label;
			Enabled = enabled;
		}
	}
}
