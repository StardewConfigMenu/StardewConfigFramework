
namespace StardewConfigFramework.Options {
	public interface IConfigOption: SCFObject {
		bool Enabled { get; set; }
		new string Label { get; set; }
	}
}
