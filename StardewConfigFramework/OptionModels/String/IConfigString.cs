using System;
namespace StardewConfigFramework.Options {
	public interface IConfigString: IConfigOption {
		public string Value { get; set; }
	}
}
