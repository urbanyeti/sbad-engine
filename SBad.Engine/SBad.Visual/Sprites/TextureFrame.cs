using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SBad.Visual.Sprites
{
	public class TextureFrame
	{
		public TextureFrame(TextureFrame textureFrame)
			: this(textureFrame.Texture, textureFrame.Rectangle)
		{
		}

		public TextureFrame(Texture2D texture, Rectangle rectangle)
		{
			Texture = texture;
			Rectangle = rectangle;
		}

		public Texture2D Texture { get; }
		public Rectangle Rectangle { get; }

		public TextureFrame NextFrame(int index)
		{
			var maxRows = Texture.Height / Rectangle.Height;
			var maxCols = Texture.Width / Rectangle.Width;

			var row = index / maxCols;
			var col = index % maxCols;

			if (row < maxRows && col < maxCols)
			{
				var nextFrame = new Rectangle(col * Rectangle.Width, row * Rectangle.Height, Rectangle.Width, Rectangle.Height);
				return new TextureFrame(Texture, nextFrame);
			}
			else
			{
				return null;
			}

			//if ((Rectangle.Width * index) + Rectangle.Width <= Texture.Width)
			//{
			//	// Go to next column
			//	nextFrame = new Rectangle((Rectangle.Width * index), Rectangle.Top, Rectangle.Width, Rectangle.Height);
			//}
			//else if ((Rectangle.Height * index) + Rectangle.Height <= Texture.Height)
			//{
			//	// Go down to next row
			//	nextFrame = new Rectangle(0, (Rectangle.Height * index), Rectangle.Width, Rectangle.Height);
			//}
			//else
			//{
			//	// Loop back to top
			//	nextFrame = new Rectangle(0, 0, Rectangle.Width, Rectangle.Height);
			//}
			
		}
	}
}
