using Microsoft.Xna.Framework.Input;

namespace SBad.Engine
{
    public interface IInputManager : IGameManager
    {
        IGameState GameState { get; }
        InputState InputState { get; }
        InputState OldInputState { get; }

        event InputManager.KeyboardKeyPressedHandler KeyboardKeyPressed;
        event InputManager.LeftButtonPressedHandler LeftButtonPressed;

        void CheckKeyboardState();
        void CheckMouseState();
    }
}