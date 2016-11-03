namespace Pacman.Handlers
{
    using Interfaces;
    using Microsoft.Xna.Framework.Input;

    public class KeyPress : IKeyPress
    {
        public bool IsPressedKey(Keys key, KeyboardState oldState)
        {
            KeyboardState newState = Keyboard.GetState();

            // Is the key down?
            if (newState.IsKeyDown(key))
            {
                // If not down last update, key has just been pressed.
                if (oldState.IsKeyUp(key))
                {
                    return true;   // Just pressed
                }
            }
            else if (oldState.IsKeyDown(key))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
            }

            return false;
        }

        public bool IsReleasedKey(Keys key, KeyboardState oldState)
        {
            KeyboardState newState = Keyboard.GetState();

            // Is the key down?
            if (newState.IsKeyDown(key))
            {
                // If not down last update, key has just been pressed.
                if (oldState.IsKeyUp(key))
                {
                    return false;        // Just pressed
                }
            }
            else if (oldState.IsKeyDown(key))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
                return true;            // Just released
            }

            return false;
        }
    }
}
