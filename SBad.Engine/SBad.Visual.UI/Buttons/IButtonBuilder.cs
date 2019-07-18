using Microsoft.Xna.Framework;
using System;

namespace SBad.Visual.UI.Buttons
{
	public interface IButtonBuilder
	{
		IButton Execute();
		IButtonBuilder SetAction(Action<IButton> action);
		IButtonBuilder SetPosition(ButtonLayout buttonLayout, Rectangle boundaryBox, int position);
		IButtonBuilder SetSize();
		IButtonBuilder SetVisual();
		IButtonBuilder SetHoverAnimation();
		IButtonBuilder SetClickAnimation();
		IButtonBuilder SetName(string name);
	}
}