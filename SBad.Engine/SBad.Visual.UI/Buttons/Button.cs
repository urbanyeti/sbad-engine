using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SBad.Visual.Sprites;

namespace SBad.Visual.UI.Buttons
{
	public class Button : IButton
	{
		public Button()
		{
		}

		public string Id { get; set; }
		public Alignment Alignment { get; set; }
		public IVisualElement Container { get; set; }
		public Padding Padding { get; set; }

		public TextureFrame Frame { get; private set; }
		public ButtonSprite Sprite { get; private set; }
		public string HoverAnimationKey { get; set; }
		public string ClickAnimationKey { get; set; }

		public int Width { get; set; }
		public int Height { get; set; }
		public Vector2 Position { get; set; }

        public Color BorderColor { get; set; }
        public int BorderWidth { get; set; }

		public SpriteFont Font { get; private set; }
		public string Text { get; private set; }
		public Color Color { get; private set; }
		public Alignment TextAlign { get; private set; }
		public Rectangle BoundaryBox
		{
			get
			{
				return new Rectangle(Position.ToPoint(), new Point(Width, Height));
			}
		}

		public Action<IButton> Action { get; set; }
		public bool IsHover { get; private set; }
        public bool AutoHeight { get; set; }
        public bool AutoWidth { get; set; }

		public void Hover(bool hover, AnimationStore animations)
		{
			IsHover = hover;
			if (hover)
			{
				Sprite.StartAnimating(animations[HoverAnimationKey]);
			}
			else
			{
				Sprite.ClearAnimation();
			}
		}
		public void Click(AnimationStore animations)
		{
			Sprite.StartAnimating(animations[ClickAnimationKey]);
		}

		public void DrawText(SpriteBatch spriteBatch)
		{
			if (Font != null && Text != null)
			{
				(var position, var origin) = this.CenterText(TextAlign);
				spriteBatch.DrawString(Font, Text, position, Color, 0, origin, 1, SpriteEffects.None, Sprite.ZOrder - .1f);
			}
		}

		public void Draw(SpriteBatch spriteBatch, TextureFrameStore textureFrames)
		{
			Sprite.Animate(Frame);
			Sprite.Draw(spriteBatch);
			DrawText(spriteBatch);
		}

		public IButton SetText(SpriteFont font, string text, Color? color = null, Alignment? textAlign = null)
		{
			Font = font;
			Text = text;
			Color = color ?? Color.Black;
			TextAlign = textAlign ?? Alignment.Center;
			return this;
		}

		public IButton SetFrame(TextureFrame frame)
		{
			Frame = frame;
			Sprite = (ButtonSprite)
				new ButtonSprite(frame)
				.SetSize(Width, Height);
			return this;
		}

        public void SetPosition(Vector2 position)
        {
            Position = position;
            Sprite.SetPosition(Position);
        }

        public IButton SetSize(int width, int height)
        {
            Width = width;
            Height = height;
            Sprite.SetSize(Width, Height);
            return this;
        }

        public IButton SetPadding(Padding padding)
        {
            Padding = padding;
            return this;
        }

        public void SetWidth(int width)
        {
            Width = width;
        }

        public void SetHeight(int height)
        {
            Height = height;
        }
    }
}
