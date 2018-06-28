using System;
namespace StardewConfigFramework.Options {
	public interface ISelection: IModOption {
		event SelectionHandler SelectionDidChange;
		ISCFOrderedDictionary<ISelectionChoice> Choices { get; }
		int SelectedIndex { get; set; }
		string SelectedIdentifier { get; set; }
		ISelectionChoice SelectedChoice { get; }
	}

	public delegate void SelectionHandler(Selection selection);
}
