using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    public class PacMan : GameObject
    {
        private int health = 100;
        //not used now,but in future
        //private int speed = 5;
        private int scores = 0;

        public PacMan(GraphicsDevice graphicsDevice, Rectangle boundingBox) //Hardcore width and height
            : base("Pacman", 0,  0, boundingBox)
        {
            using (var stream = TitleContainer.OpenStream("Content/PacManSprite_sheets.png"))
            {
                base.Texture = Texture2D.FromStream(graphicsDevice, stream);
            }
        }

        public int Scores
        {
            get { return scores; }
            set { scores = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }
    }
}