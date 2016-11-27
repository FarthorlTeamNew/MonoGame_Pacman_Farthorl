﻿namespace Pacman.Models.LevelObjects
{
    using Core;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;

    public abstract class Fruit : LevelObject
    {
        protected Fruit(Texture2D texture, Rectangle boundingBox)
            : base(texture, 0, 0, boundingBox)
        {
        }

        public int FruitBonus { get; set; }

        public override void ReactOnCollision(PacMan pacMan)
        {
            //Just simple logic to heal the pacman with fruit bonus.. but not to overcome 
            if (pacMan.Health + this.FruitBonus <= 100)
            {
                pacMan.Health += this.FruitBonus;
            }
            else
            {
                pacMan.Health = 100;
            }
            Engine.sound.PacManEatGhost();
        }

        public abstract void ActivatePowerup(ModelGenerator ghostGen, PacMan pacMan);
    }
}