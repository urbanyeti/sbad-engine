using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SBad.Visual.Sprites;

namespace SBad.Visual
{
	public abstract class VisualElement : IVisualElement
	{
		public string Id { get; set; }
		public Alignment Alignment { get; set; }
		public IVisualElement Container { get; set; }
		public Padding Padding { get; set; } = new Padding();

		public int Width { get; set; }
		public int Height { get; set; }

        public bool AutoHeight { get; set; } = false;
        public bool AutoWidth { get; set; } = false;

		public Vector2 Position { get; set; }
		public Rectangle BoundaryBox { get => new Rectangle(Position.ToPoint(), new Point(Width, Height)); }

        public Color Color { get; set; }

        public Color BorderColor { get; set; }
        public int BorderWidth { get; set; }

        public abstract void Draw(SpriteBatch spriteBatch, TextureFrameStore textureFrames);

        public virtual void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public virtual void SetWidth(int width)
        {
            Width = width;
        }

        public virtual void SetHeight(int height)
        {
            Height = height;
        }
    }
}
