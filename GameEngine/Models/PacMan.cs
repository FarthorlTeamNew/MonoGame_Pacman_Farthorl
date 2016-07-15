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

        public PacMan(GraphicsDevice graphicsDevice) //Hardcore width and height
            : base("Pacman", 0,  0)
        {
            if (base.Texture == null)
            {
                using (var stream = TitleContainer.OpenStream("Content/PacManSprite_sheets.png"))
                {
                    base.Texture = Texture2D.FromStream(graphicsDevice, stream);
                }
            }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }
    }
}