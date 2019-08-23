using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SBad.Visual.UI;
using SBad.Visual.UI.Buttons;

namespace SBad.Engine
{
    public class InputManager : IInputManager
    {
        public InputManager(IGameState gameState)
        {
            GameState = gameState;
        }

        public IGameState GameState { get; }

        public event LeftButtonPressedHandler LeftButtonPressed;
        public event KeyboardKeyPressedHandler KeyboardKeyPressed;

        public void CheckMouseState(MouseState state)
        {
            var oldMouseState = GameState.InputState.OldMouseState;

            if (state.LeftButton == ButtonState.Pressed)
            {
                if ((oldMouseState.LeftButton != ButtonState.Pressed))
                {
                    OnLeftButtonPressed(new LeftButtonPressedEventArgs(state.Position));
                }
            }
        }

        public void CheckKeyboardState(KeyboardState state)
        {
            var oldKeyboardState = GameState.InputState.OldKeyboardState;

            foreach (Keys key in state.GetPressedKeys())
            {
                if (oldKeyboardState.IsKeyDown(key))
                {
                    // Being held
                }
                else
                {
                    OnKeyboardKeyPressed(new KeyboardKeyPressedEventArgs(key));
                }
            }
        }

        protected virtual void OnLeftButtonPressed(LeftButtonPressedEventArgs e)
        {
            LeftButtonPressed?.Invoke(this, e);
        }

        protected virtual void OnKeyboardKeyPressed(KeyboardKeyPressedEventArgs e)
        {
            KeyboardKeyPressed?.Invoke(this, e);
        }

        public delegate void LeftButtonPressedHandler(object sender, LeftButtonPressedEventArgs e);
        public delegate void KeyboardKeyPressedHandler(object sender, KeyboardKeyPressedEventArgs e);

        public class LeftButtonPressedEventArgs : EventArgs
        {
            public LeftButtonPressedEventArgs(Point clickPoint)
            {
                ClickPoint = clickPoint;
            }
            public Point ClickPoint { get; }
        }

        public class KeyboardKeyPressedEventArgs : EventArgs
        {
            public KeyboardKeyPressedEventArgs(Keys key)
            {
                Key = key;
            }
            public Keys Key { get; }
        }

        public enum InputKey
        {
            LeftMouse,
            ControlLeftMouse,
            RightMouse,
            N,
            E,
            S,
            W,
            Space
        }
    }
}

