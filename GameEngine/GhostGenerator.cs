using System;
using System.Collections.Generic;
using GameEngine.Animators;
using GameEngine.Animators.GhostAnimators;
using GameEngine.Globals;
using GameEngine.Handlers;
using GameEngine.Interfaces;
using GameEngine.Models;
using GameEngine.Models.LevelObjects;
using GameEngine.Models.LevelObjects.Ghosts;
using Microsoft.Xna.Framework;

namespace GameEngine.Factories
{
    public class GhostGenerator
    {
        private Dictionary<string, Ghost> ghosts;
        private Dictionary<string, Animator> ghostAnimators;
        private Dictionary<string, IMovable> ghostMovements;
        private Ghost blinky;
        private Ghost clyde;
        private Ghost inky;
        private Ghost pinky;

        public GhostGenerator(Matrix levelMatrix, PacMan pacMan)
        {
            ghosts = new Dictionary<string, Ghost>();
            ghostAnimators = new Dictionary<string, Animator>();
            ghostMovements = new Dictionary<string, IMovable>();

            this.Ghosts = this.GetGhosts(levelMatrix);
            this.GhostAnimators = this.GetGhostAnimators();
            this.GhostMovements = this.GetGhostMovements(levelMatrix, pacMan);
        }

        public void LoadContent()
        {
            
        }

        public Dictionary<string, Ghost> Ghosts { get; private set; }
        public Dictionary<string, Animator> GhostAnimators { get; private set; }
        public Dictionary<string, IMovable> GhostMovements { get; private set; }

        private Dictionary<string, Ghost> GetGhosts(Matrix levelMatrix)
        {
            blinky = new Blinky(GameTexture.pacmanAndGhost, 0, 0, new Rectangle(0, 0, 32, 32));
            clyde = new Clyde(GameTexture.pacmanAndGhost, 0, 0, new Rectangle(0, 0, 32, 32));
            inky = new Inky(GameTexture.pacmanAndGhost, 0, 0, new Rectangle(0, 0, 32, 32));
            pinky = new Pinky(GameTexture.pacmanAndGhost, 0, 0, new Rectangle(0, 0, 32, 32));

            ghosts.Add(nameof(Blinky), blinky);
            ghosts.Add(nameof(Clyde), clyde);
            ghosts.Add(nameof(Inky), inky);
            ghosts.Add(nameof(Pinky), pinky);

            foreach (var kvp in ghosts)
            {
                PlaceOnRandomXY(kvp.Value, levelMatrix);
            }
            return ghosts;
        }

        private Dictionary<string, Animator> GetGhostAnimators()
        {
            ghostAnimators.Add(nameof(Blinky), new BlinkyAnimator(blinky));
            ghostAnimators.Add(nameof(Clyde), new ClydeAnimator(clyde));
            ghostAnimators.Add(nameof(Inky), new InkyAnimator(inky));
            ghostAnimators.Add(nameof(Pinky), new PinkyAnimator(pinky));
            return ghostAnimators;
        }

        private Dictionary<string, IMovable> GetGhostMovements(Matrix levelMatrix, PacMan pacMan)
        {
            ghostMovements.Add(nameof(Blinky), new GhostWeakRandomMovement(blinky, levelMatrix));
            ghostMovements.Add(nameof(Clyde), new GhostGoodRandomMovement(clyde, levelMatrix));
            ghostMovements.Add(nameof(Inky), new GhostHuntingRandomMovement(inky, levelMatrix, pacMan));
            ghostMovements.Add(nameof(Pinky), new GhostHuntingRandomMovement(pinky, levelMatrix, pacMan));
            return ghostMovements;
        }

        private void PlaceOnRandomXY(Ghost ghost, Matrix levelMatrix)
        {
            string[] placeAvailable = AvailableXY(levelMatrix).Split();
            int placeGhostX = int.Parse(placeAvailable[0]);
            int placeGhostY = int.Parse(placeAvailable[1]);
            ghost.X = placeGhostX * Global.quad_Width;
            ghost.Y = placeGhostY * Global.quad_Height;
            ghost.UpdateBoundingBox();
        }

        private string AvailableXY(Matrix levelMatrix)
        {
            while (true)
            {
                int tryX = new Random(DateTime.Now.Millisecond).Next(3, Global.XMax - 1);
                int tryY = new Random(DateTime.Now.Millisecond).Next(3, Global.YMax - 1);
                var elements = levelMatrix.PathsMatrix[tryY, tryX].Trim().Split(',');
                if (int.Parse(elements[1]) == 1)
                {
                    levelMatrix.PathsMatrix[tryY, tryX] = "0,0";
                    return $"{tryX} {tryY}";
                }
            }
        }
    }
}