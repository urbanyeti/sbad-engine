using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SBad.Visual.Sprites;
using System.Text;

namespace SBad.Visual.UI
{
    public class TextBox : VisualElement, IText
    {
        public TextBox(SpriteFont font, Color? color = null, Alignment? alignment = null, bool? textWrap = null)
        {
            Font = font;
            Color = color ?? Color.White;
            Alignment = alignment ?? Alignment.Top | Alignment.Left;
            TextWrap = textWrap ?? true;
        }
        public SpriteFont Font { get; }
        public string Text { get; private set; }
        public string TextRaw { get; private set; }
        public Color Color { get; private set; }
        public bool TextWrap { get; private set; }
        public Alignment TextAlign { get { return Alignment; } }

        public TextBox SetText(string text, Color? color = null, Alignment? alignment = null, bool? textWrap = null)
        {
            Color = color ?? Color;
            Alignment = alignment ?? Alignment;
            TextWrap = textWrap ?? TextWrap;

            TextRaw = text;
            Text = TextWrap ? _WrapText(TextRaw) : TextRaw;
            return this;
        }

        public override void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public override void SetWidth(int width)
        {
            Width = width;
            Text = TextWrap ? _WrapText(TextRaw) : TextRaw;
        }

        public override void Draw(SpriteBatch spriteBatch, TextureFrameStore textureFrames)
        {
            DrawText(spriteBatch);
        }

        public void DrawText(SpriteBatch spriteBatch)
        {
            if (Font != null && Text != null)
            {
                (var position, var origin) = this.CenterText(TextAlign);
                position += new Vector2(Padding.Left, Padding.Top);
                spriteBatch.DrawString(Font, Text, position, Color, 0, origin, 1, SpriteEffects.None, 1);
            }
        }

        private string _WrapText(string text)
        {
            if (Padding.Left + Font.MeasureString(text).X < Width - Padding.Right)
            {
                return text;
            }

            string[] words = text.Split(' ');
            StringBuilder wrappedText = new StringBuilder();
            float linewidth = 0f;
            float spaceWidth = Font.MeasureString(" ").X;
            for (int i = 0; i < words.Length; ++i)
            {
                Vector2 size = Font.MeasureString(words[i]);
                if (Padding.Left + linewidth + size.X < Width - Padding.Right)
                {
                    linewidth += size.X + spaceWidth;
                }
                else
                {
                    wrappedText.Append("\n");
                    linewidth = size.X + spaceWidth;
                }
                wrappedText.Append(words[i]);
                wrappedText.Append(" ");
            }

            return wrappedText.ToString();
        }
    }
}
