using StardewConfigFramework.Options;

namespace StardewConfigFramework {
	public interface IOptionsTab {
		ISCFOrderedDictionary<IConfigOption> Options { get; }
		T GetOption<T>(string identifier) where T : IConfigOption;
		T GetOption<T>(int index) where T : IConfigOption;
	}
}