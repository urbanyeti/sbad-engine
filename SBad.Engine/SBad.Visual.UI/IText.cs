using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SBad.Visual.UI
{
	public interface IText : IVisualElement
	{
		SpriteFont Font { get; }
		string Text { get; }
		Color Color { get; }
		Alignment TextAlign { get; }

		void DrawText(SpriteBatch spriteBatch);
	}
}
