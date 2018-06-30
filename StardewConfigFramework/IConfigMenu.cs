namespace StardewConfigFramework {

	public delegate void ModAddedSettings();

	public abstract class IConfigMenu {
		public abstract void AddOptionsPackage(IOptionsPackage package);
	}
}
