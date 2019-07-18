using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SBad.Visual.Sprites
{
    public interface ISprite
    {
        TextureFrame Frame { get; }
		Vector2 Position { get; }
		int Width { get; }
        int Height { get; }
		int ZOrder { get; set; }
		bool Visible { get; set; }
		Rectangle DestinationRectangle { get; }

		ISprite SetFrame(TextureFrame frame);
		ISprite SetSize(int width, int height);
		ISprite SetPosition(Vector2 position);
		void Draw(SpriteBatch spriteBatch);
	}
}