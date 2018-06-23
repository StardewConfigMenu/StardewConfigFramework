
namespace StardewConfigFramework {

	public delegate void ModAddedSettings();

	public abstract class IConfigMenu {
		public static IConfigMenu Instance { get; protected set; }
		public abstract void AddModOptions(IOptionsPackage modOptions);
	}
}
