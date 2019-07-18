using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SBad.Visual.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBad.Visual.UI
{
    public class Image : VisualElement, IText
    { 
        public Image(int width, int height, TextureFrame spriteTexture)
        {
            //Position = position;
            Width = width;
            Height = height;
            Sprite = new PictureSprite(spriteTexture);
            //Sprite.SetPosition(position);
            Sprite.SetSize(Width, Height);
        }
        public Sprite Sprite { get; }

        public SpriteFont Font { get; private set; }
        public string Text { get; private set; }
        public Color Color { get; private set; }
        public Alignment TextAlign { get; private set; }

        public override void SetPosition(Vector2 position)
        {
            Position = position;
            Sprite.SetPosition(position);
            Sprite.SetSize(Width, Height);
        }

        public Image SetText(SpriteFont font, string text, Color? color = null, Alignment? textAlign = null)
        {
            Font = font;
            Text = text;
            Color = color ?? Color.Black;
            TextAlign = textAlign ?? Alignment.Center;
            return this;
        }

        public override void Draw(SpriteBatch spriteBatch, TextureFrameStore textureFrames)
        {
            Sprite.Draw(spriteBatch);
            DrawText(spriteBatch);
        }

        public void DrawText(SpriteBatch spriteBatch)
        {
            if (Font != null && Text != null)
            {
                (var position, var origin) = this.CenterText(TextAlign);
                spriteBatch.DrawString(Font, Text, position, Color, 0, origin, 1, SpriteEffects.None, Sprite.ZOrder - .1f);
            }
        }
    }
}
