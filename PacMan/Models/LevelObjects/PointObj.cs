namespace Pacman.Models.LevelObjects
{
    using Core;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Globals;

    public class PointObj : LevelObject
    {
        public PointObj(Texture2D texture ,float x, float y, Rectangle boundingBox)
            : base(texture, x, y, boundingBox)
        {

        }

        public override void ReactOnCollision(PacMan pacman)
        {
            Engine.sound.EatFruit();
            pacman.Scores++;
            GameStatistic.PlayerPointsEaten += 1;
        }
    }
}