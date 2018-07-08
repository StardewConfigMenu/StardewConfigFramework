using System;
namespace StardewConfigFramework.Options {
	public interface IConfigString: IConfigOption {
		event StringHandler StringWasChanged;
		string Value { get; set; }
	}

	public delegate void StringHandler(IConfigString configString);

}
