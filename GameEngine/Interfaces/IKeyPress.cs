using Microsoft.Xna.Framework.Input;

namespace Pacman.Interfaces
{
    public interface IKeyPress
    {
        bool IsPressedKey(Keys key, KeyboardState oldState);

        bool IsReleasedKey(Keys key, KeyboardState oldState);
    }
}
