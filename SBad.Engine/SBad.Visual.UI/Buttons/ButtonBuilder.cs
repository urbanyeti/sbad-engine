using System;
using Microsoft.Xna.Framework;
using SBad.Visual.Sprites;

namespace SBad.Visual.UI.Buttons
{
	public abstract class ButtonBuilder : IButtonBuilder
	{
		protected IButton _Button { get; } = new Button();

		public virtual IButtonBuilder SetName(string name)
		{
			_Button.Id = name;
			return this;
		}

		public virtual IButtonBuilder SetPosition(ButtonLayout buttonLayout, Rectangle boundaryBox, int position)
		{
			int x = 0, y = 0;
			int xPadding = 1, yPadding = 1;
			int row = 0, col = 0;

			var maxRows = Math.Max(boundaryBox.Height / _Button.Sprite.Height, 1);
			var maxCols = Math.Max(boundaryBox.Width / _Button.Sprite.Width, 1);

			switch (buttonLayout)
			{
				case ButtonLayout.LeftToRight:
					row = position / maxCols;
					col = position % maxCols;
					break;
				case ButtonLayout.TopToBottom:
					row = position % maxCols;
					col = position / maxCols;
					break;
			}

			if (row >= maxRows || col >= maxCols)
			{
				BuildFailed($"Invalid button position: ({row},{col})");
			}

			x = (col * _Button.Sprite.Width + xPadding) + boundaryBox.Left;
			y = (row * _Button.Sprite.Height + yPadding) + boundaryBox.Top;

			_Button.SetPosition(new Vector2(x, y));
			_Button.Sprite.SetPosition(_Button.Position);
			return this;
		}

		public IButtonBuilder SetAction(Action<IButton> action)
		{
			_Button.Action = action;
			return this;
		}

		public IButton Execute()
		{
			return _Button;
		}

		public abstract IButtonBuilder SetHoverAnimation();

		public IButtonBuilder SetHoverAnimation(string key)
		{
			_Button.HoverAnimationKey = key;
			return this;
		}
		public abstract IButtonBuilder SetClickAnimation();
		public IButtonBuilder SetClickAnimation(string key)
		{
			_Button.ClickAnimationKey = key;
			return this;
		}
		public abstract IButtonBuilder SetVisual();
		public IButtonBuilder SetTextureFrame(string key, TextureFrameStore textureFrames)
		{
			_Button.SetFrame(textureFrames[key]);
			return this;
		}
		public abstract IButtonBuilder SetSize();
		public IButtonBuilder SetSize(int width, int height)
		{
			_Button.Width = width;
			_Button.Height = height;
			return this;
		}

        public void BuildFailed(string message)
        {
            throw new ButtonBuildFailure(message);
        }
	}
}
