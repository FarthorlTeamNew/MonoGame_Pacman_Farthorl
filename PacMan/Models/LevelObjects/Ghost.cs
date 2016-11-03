namespace Pacman.Models.LevelObjects
{
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;
    using System.Diagnostics;

    public abstract class Ghost : LevelObject
    {
        public Stopwatch GhostTransformingTimer;

        protected Ghost(Texture2D texture, Rectangle boundingBox)
            : base(texture, 0, 0, boundingBox)
        {
            this.Hungry = false;
            this.CanKillPakman = true;
            this.GhostTransformingTimer = new Stopwatch();
        }

        protected Ghost(): base() { } // is it right to have constructor for test purpose

        public override void ReactOnCollision(PacMan pacMan)
        {      
            //Just to check the collisin, TODO real collision details   
        }

        public bool Hungry { get; set; }

        public bool CanKillPakman { get; set; }

        public virtual void GimmeFood()
        {
            this.Hungry = true;
        }

        public virtual void EnoughIsEnough()
        {
            this.Hungry = false;
        }

        public void StartTransformingToGhost()
        {
            this.GhostTransformingTimer.Start();
        }
    }
}