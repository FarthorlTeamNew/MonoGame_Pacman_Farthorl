using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces
{
    public interface IMovable
    {
        Vector2 Move(GameTime gameTime);
        void Reset();
    }
}
