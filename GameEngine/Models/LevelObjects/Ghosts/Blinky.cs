namespace Pacman.Models.LevelObjects.Ghosts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Blinky : Ghost
    {
        public Blinky(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            this.Hungry = false;
        }

    }
}
