namespace Pacman.Models.LevelObjects
{
    using Core;
    using Globals;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Data;

    public class GhostKiller : LevelObject
    {
        public GhostKiller(Texture2D texture, Rectangle boundingBox) 
            : base(texture, 0, 0, boundingBox)
        {
        }

        public override void ReactOnCollision(PacMan pacman)
        {
            pacman.CanEat = true;
            pacman.Texture = GameTexture.PacmanPokeball;
            Engine.sound.PacManEatGhost();
            DataBridge.GetUserData().PlayerStatistic.PlayerGhostkillersEaten++;
        }
    }
}