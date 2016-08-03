namespace GameEngine.Models.LevelObjects.Ghosts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Pinky : Ghost
    {
        public Pinky(Texture2D texture,  Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            this.Hungry = false;
        }

        public override void ReactOnCollision(PacMan pacMan)
        {
            //Just to check the collisin, TODO real collision details   
        }

        public bool Hungry { get; private set; }
    }
}
