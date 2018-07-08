using System;
namespace StardewConfigFramework.Options {
	public class ConfigString: ConfigOption, IConfigString {
		public ConfigString(string identifier, string label, bool enabled = true) : base(identifier, label, enabled) {

		}

		public string Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}
}
