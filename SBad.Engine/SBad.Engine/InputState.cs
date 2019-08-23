using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBad.Engine
{
	public class InputState
	{
        public InputState() { }

        public InputState(InputState inputState)
            : this(inputState.MouseState, inputState.KeyboardState, inputState.GamePadState) { }

        public InputState(MouseState mouseState, KeyboardState keyboardState, GamePadState gamePadState)
        {
            MouseState = mouseState;
            KeyboardState = keyboardState;
            GamePadState = gamePadState;
        }

        public MouseState MouseState { get; }
        public KeyboardState KeyboardState { get; }
        public GamePadState GamePadState { get; }
	}
}
