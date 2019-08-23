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
        public InputState InputState => GameState.InputState;
        public InputState OldInputState => GameState.OldInputState;

        public event LeftButtonPressedHandler LeftButtonPressed;
        public event KeyboardKeyPressedHandler KeyboardKeyPressed;

        public void Update()
        {
            GameState.OldInputState = new InputState(InputState);
            GameState.InputState = new InputState(
                Mouse.GetState(),
                Keyboard.GetState(),
                GamePad.GetState(0)
            );
        }

        public void CheckMouseState()
        {
            var mouseState = GameState.InputState.MouseState;
            var oldMouseState = GameState.OldInputState.MouseState;

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if ((oldMouseState.LeftButton != ButtonState.Pressed))
                {
                    OnLeftButtonPressed(new LeftButtonPressedEventArgs(mouseState.Position));
                }
            }
        }

        public void CheckKeyboardState()
        {
            var keyboardState = GameState.InputState.KeyboardState;
            var oldKeyboardState = GameState.OldInputState.KeyboardState;

            foreach (Keys key in keyboardState.GetPressedKeys())
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

