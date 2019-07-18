using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SBad.Visual.Sprites
{
    public abstract class Sprite : ISprite
    {
		public Sprite(TextureFrame frame)
		{
			Frame = frame;
		}

		public TextureFrame Frame { get; private set; }
		public Vector2 Position { get; private set; } = new Vector2(0, 0);
		public int Width { get; private set; } = 0;
		public int Height { get; private set; } = 0;
		public int ZOrder { get; set; } = 1;
		public bool Visible { get; set; } = true;
		public Rectangle DestinationRectangle
		{
			get
			{
				return new Rectangle(Position.ToPoint(), new Point(Width, Height));
			}
		}

		public virtual ISprite SetFrame (TextureFrame frame)
		{
			Frame = frame;
			return this;
		}

		public virtual ISprite SetSize (int width, int height)
		{
			Width = width;
			Height = height;
			return this;
		}

		public virtual ISprite SetPosition(Vector2 position)
		{
			Position = position;
			return this;
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
            spriteBatch.Draw(Frame.Texture, DestinationRectangle, Frame.Rectangle, Color.White);
		}
	}
}