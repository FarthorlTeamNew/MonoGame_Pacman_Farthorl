using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects
{
    public class Wall : LevelObject
    {
        public Wall(Texture2D texture, float x, float y, Rectangle boundingBox)
            : base("Wall" , x, y, boundingBox)
        {
            this.Texture = texture;
        }

        public override void ReactOnCollision(PacMan pacMan)
        {
            
        }
    }
}
