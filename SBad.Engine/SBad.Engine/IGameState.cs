using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SBad.Visual.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBad.Engine
{
    public interface IGameState
    {
        GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        SpriteBatch SpriteBatch { get; set; }
        TextureFrameStore TextureFrameStore { get; set; }
        GameTime GameTime { get; set; }
        InputState InputState { get; set; }
    }
}
