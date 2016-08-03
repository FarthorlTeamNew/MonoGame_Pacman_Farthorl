namespace GameEngine.Models.LevelObjects
{
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;

    public abstract class Ghost : LevelObject
    {
        protected Ghost(Texture2D texture, Rectangle boundingBox)
            : base(texture, 0, 0, boundingBox)
        {
            this.Hungry = false;
        }

        public override void ReactOnCollision(PacMan pacMan)
        {      
            //Just to check the collisin, TODO real collision details   
        }

        public bool Hungry { get; set; }

        public virtual void GimmeFood()
        {
            this.Hungry = true;
        }

        public virtual void EnoughIsEnough()
        {
            this.Hungry = false;
        }
    }
}