using Microsoft.Xna.Framework.Graphics;
using SBad.Core.Structures;

namespace SBad.Visual.Sprites
{
    public class SpriteFontId : IIdentity
    {
        public SpriteFontId(string id, SpriteFont font)
        {
            Id = id;
            Font = font;
        }

        public string Id { get; set; }
        public SpriteFont Font { get; set; }
    }
}
