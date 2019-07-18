using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SBad.Visual.Sprites;
using System;

namespace SBad.Visual.UI.Buttons
{
	public interface IButton : IText
	{
		TextureFrame Frame { get; }
		ButtonSprite Sprite { get; }
		string HoverAnimationKey { get; set; }
		string ClickAnimationKey { get; set; }
		Action<IButton> Action { get; set; }
		void Hover(bool hover, AnimationStore animations);
		void Click(AnimationStore animations);

		IButton SetFrame(TextureFrame frame);
		IButton SetText(SpriteFont font, string text, Color? color = null, Alignment? alignment = null);
        IButton SetSize(int width, int height);
        IButton SetPadding(Padding padding);
    }
}