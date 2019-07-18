namespace SBad.Visual.Sprites
{
	public class Animation
	{
		public Animation(Animation animation)
			:this(animation.Frame, animation.StartIndex, animation.StopIndex, animation.Loop, animation.Hold)
		{
		}

		public Animation(TextureFrame frame, int startIndex, int stopIndex, bool loop = false, bool hold = false)
		{
			Frame = frame;
			StartIndex = startIndex;
			StopIndex = stopIndex;
			Loop = loop;
			Hold = hold;
		}

		public TextureFrame Frame { get; private set; }
		public int StartIndex { get; }
		public int CurrentIndex { get; private set; }
		public int StopIndex { get; private set; }
		public bool IsAnimating { get; private set; } = false;
		public bool Loop { get; private set; }
		public bool Hold { get; private set; }

		public TextureFrame StartAnimation()
		{
			IsAnimating = true;
			CurrentIndex = StartIndex;
			Frame = Frame.NextFrame(CurrentIndex);
			return Frame;
		}

		public bool Animate()
		{
			if (IsAnimating)
			{
				if (CurrentIndex < StopIndex)
				{
					Frame = Frame.NextFrame(CurrentIndex);
					CurrentIndex++;
				}
				else if (Loop)
				{
					CurrentIndex = StartIndex;
					Frame.NextFrame(CurrentIndex);
				}
				else
				{
					IsAnimating = false;
				}
			}
			return IsAnimating;
		}
	}
}
