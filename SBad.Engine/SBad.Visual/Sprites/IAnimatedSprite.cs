namespace SBad.Visual.Sprites
{
	public interface IAnimatedSprite
	{
		Animation Animation { get; }
		void StartAnimating(Animation animation);
		void Animate(TextureFrame defaultFrame);
	}
}
