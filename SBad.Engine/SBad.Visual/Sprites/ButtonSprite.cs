namespace SBad.Visual.Sprites
{
	public class ButtonSprite : Sprite, IAnimatedSprite
	{
		public ButtonSprite(TextureFrame frame)
			: base(frame)
		{
		}

		public Animation Animation { get; private set; }

		public void StartAnimating(Animation animation)
		{
			Animation = animation;
			SetFrame(animation.StartAnimation());

		}
		public void ClearAnimation()
		{
			Animation = null;
		}

		public void Animate(TextureFrame defaultFrame)
		{
			if (Animation != null && (Animation.Animate() || Animation.Hold))
			{
				SetFrame(Animation.Frame);
			}
			else
			{
				ClearAnimation();
				SetFrame(defaultFrame);
			}
		}
	}
}
