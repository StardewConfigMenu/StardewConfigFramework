using StardewConfigFramework.Options;

namespace StardewConfigFramework {
	public interface IOptionsTab: SCFObject {
		IOrderedDictionary<IConfigOption> Options { get; }
		T GetOption<T>(string identifier) where T : IConfigOption;
		T GetOption<T>(int index) where T : IConfigOption;
	}
}