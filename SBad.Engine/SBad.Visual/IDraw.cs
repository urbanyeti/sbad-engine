using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SBad.Core.Structures;
using SBad.Visual.Sprites;

namespace SBad.Visual
{
	public interface IDraw : IIdentity
	{
		int Width { get; set; }
		int Height { get; set; }
		Vector2 Position { get; }
		Rectangle BoundaryBox { get; }

		void Draw(SpriteBatch spriteBatch, TextureFrameStore textureFrames);
        void SetPosition(Vector2 position);
    }
}
