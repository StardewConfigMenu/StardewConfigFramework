
namespace StardewConfigFramework.Options {

	public class Toggle: ModOption {
		public delegate void Handler(string identifier, bool isOn);
		public event Handler ValueDidChange;

		public Toggle(string identifier, string labelText, bool isOn = true, bool enabled = true) : base(identifier, labelText, enabled) {
			this.IsOn = isOn;
		}

		public bool IsOn {
			get {
				return _isOn;
			}
			set {
				if (_isOn == value)
					return;

				this._isOn = value;
				this.ValueDidChange?.Invoke(this.Identifier, this.IsOn);
			}
		}

		private bool _isOn;

		public void Flip() {
			this.IsOn = !this.IsOn;
		}
	}
}
