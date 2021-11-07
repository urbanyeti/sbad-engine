using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SBad.Visual.Sprites;

namespace SBad.Visual
{
    public static class VisualElementExtensions
    {
        public static void ColorFill(this IVisualElement element, SpriteBatch spriteBatch, TextureFrameStore textureFrames)
        {
            var pixel = textureFrames["pixel"].Texture;
            var rectangleToDraw = element.BoundaryBox;

            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, rectangleToDraw.Height), element.Color);
        }

        public static void DrawBorder(this IVisualElement element, SpriteBatch spriteBatch, TextureFrameStore textureFrames)
        {
            var pixel = textureFrames["pixel"].Texture;
            var rectangleToDraw = element.BoundaryBox;

            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, element.BorderWidth), element.BorderColor);

            // Draw left line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, element.BorderWidth, rectangleToDraw.Height), element.BorderColor);

            // Draw right line
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - element.BorderWidth),
                rectangleToDraw.Y,
                element.BorderWidth,
                rectangleToDraw.Height), element.BorderColor);
            // Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                rectangleToDraw.Y + rectangleToDraw.Height - element.BorderWidth,
                rectangleToDraw.Width,
                element.BorderWidth), element.BorderColor);
        }
    }
}
