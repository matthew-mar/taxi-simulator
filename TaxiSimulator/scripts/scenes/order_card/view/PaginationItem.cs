using Godot;

namespace TaxiSimulator.Scenes.OrderCard.View {
	public partial class PaginationItem : TextureRect {
		public int Offset { get; set; }

		private TextureButton _textureButton = null;

		public TextureButton TextureButton {
			get {
				_textureButton ??= GetNode<TextureButton>("item_button");
				return _textureButton;
			}
		}
	}
}
