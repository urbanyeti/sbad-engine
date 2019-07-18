using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBad.Visual.UI
{
	public static class UIExtensions
	{
		public static (Vector2 position, Vector2 origin) CenterText(this IText textObj, Alignment alignment)
		{
			Rectangle bounds = textObj.BoundaryBox;
			Vector2 textSize = textObj.Font.MeasureString(textObj.Text);

			Vector2 textOrigin = textSize * .5f;

			Vector2 position = textObj.BoundaryBox.Center.ToVector2();

			if (alignment.HasFlag(Alignment.Left))
				textOrigin.X += bounds.Width / 2 - textSize.X / 2;

			if (alignment.HasFlag(Alignment.Right))
				textOrigin.X -= bounds.Width / 2 - textSize.X / 2;

			if (alignment.HasFlag(Alignment.Top))
				textOrigin.Y += bounds.Height / 2 - textSize.Y / 2;

			if (alignment.HasFlag(Alignment.Bottom))
				textOrigin.Y -= bounds.Height / 2 - textSize.Y / 2;

			return (position, textOrigin);
		}

		public static Vector2 PositionOn(this IDraw obj, Rectangle bounds, Alignment alignment)
		{
			return bounds.PositionOn(obj.Width, obj.Height, alignment);
		}

		public static Vector2 PositionOn(this Rectangle bounds, int width, int height , Alignment alignment)
		{
			Vector2 position = bounds.Center.ToVector2();

			//Center by default
			position.X -= (width * .5f);
			position.Y -= (height * .5f);

			if (alignment.HasFlag(Alignment.Left))
			{
				position.X = bounds.X; //(obj.Width * .5f);
			}
			if (alignment.HasFlag(Alignment.Right))
			{
				position.X = bounds.X + bounds.Width - width;
			}
			if (alignment.HasFlag(Alignment.Top))
			{
				position.Y = bounds.Y;
			}
			if (alignment.HasFlag(Alignment.Bottom))
			{
				position.Y = bounds.Y + bounds.Height - height;
			}

			return position;
		}
	}
}
