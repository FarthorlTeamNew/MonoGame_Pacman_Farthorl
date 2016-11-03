namespace Pacman.Models.LevelObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Wall : LevelObject
    {
        public Wall(Texture2D texture, float x, float y, Rectangle boundingBox)
            : base(texture , x, y, boundingBox)
        {

        }

        public override void ReactOnCollision(PacMan pacMan)
        {
            
        }
    }
}
