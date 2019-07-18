using System.Collections.Generic;

namespace SBad.Visual.Sprites
{
	public class AnimationStore
	{
		protected Dictionary<string, Animation> Animations { get; } = new Dictionary<string, Animation>();
		public AnimationStore AddAnimation(string key, Animation animation)
		{
			Animations[key] = animation;
			return this;
		}

		public Animation this[string key]
		{
			get { return new Animation(Animations[key]); }
			set { Animations[key] = value; }
		}
	}
}
