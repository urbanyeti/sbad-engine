using Microsoft.Xna.Framework.Input;

namespace SBad.Engine
{
    public interface IInputManager : IGameManager
    {
        IGameState GameState { get; }

        event InputManager.KeyboardKeyPressedHandler KeyboardKeyPressed;
        event InputManager.LeftButtonPressedHandler LeftButtonPressed;

        void CheckKeyboardState(KeyboardState state);
        void CheckMouseState(MouseState state);
    }
}