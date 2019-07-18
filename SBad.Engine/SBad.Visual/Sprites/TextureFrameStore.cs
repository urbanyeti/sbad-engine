using System.Collections.Generic;

namespace SBad.Visual.Sprites
{
	public class TextureFrameStore
	{
		protected Dictionary<string, TextureFrame> TextureFrames { get; } = new Dictionary<string, TextureFrame>();
		public TextureFrameStore AddTextureFrame(string key, TextureFrame textureFrame)
		{
			TextureFrames[key] = textureFrame;
			return this;
		}

		public TextureFrame this[string key]
		{
			get { return new TextureFrame(TextureFrames[key]); }
			set { TextureFrames[key] = value; }
		}
	}
}
