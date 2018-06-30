using StardewConfigFramework.Options;

namespace StardewConfigFramework {
	public interface IOptionsTab {
		T GetOption<T>(string identifier) where T : IConfigOption;
		T GetOption<T>(int index) where T : IConfigOption;
	}
}