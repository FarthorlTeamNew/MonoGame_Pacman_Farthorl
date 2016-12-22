namespace Pacman.Core
{
    using System;
    using System.Collections.Generic;
    using Animators;
    using Animators.GhostAnimators;
    using Globals;
    using Handlers;
    using Interfaces;
    using Models;
    using Models.LevelObjects;
    using Models.LevelObjects.Ghosts;
    using Microsoft.Xna.Framework;
    using System.Linq;

    public class ModelGenerator : IDisposable
    {
        private Dictionary<string, Ghost> ghosts;
        private Dictionary<string, Animator> animationModels;
        private Dictionary<string, IMovable> movableModels;
        private Ghost blinky;
        private Ghost clyde;
        private Ghost inky;
        private Ghost pinky;

        public ModelGenerator(Matrix levelMatrix, PacMan pacMan)
        {
            this.ghosts = new Dictionary<string, Ghost>();
            this.animationModels = new Dictionary<string, Animator>();
            this.movableModels = new Dictionary<string, IMovable>();

            this.Ghosts = this.AddGhosts(levelMatrix);
            this.AnimationModels = this.AddAnimators(pacMan);
            this.MovableModels = this.AddMovements(levelMatrix, pacMan);
        }

        public Dictionary<string, Ghost> Ghosts { get; private set; }
        public Dictionary<string, Animator> AnimationModels { get; private set; }
        public Dictionary<string, IMovable> MovableModels { get; private set; }

        private Dictionary<string, Ghost> AddGhosts(Matrix levelMatrix)
        {
            this.blinky = new Blinky(GameTexture.PacmanAndGhost, new Rectangle(0, 0, Global.quad_Width, Global.quad_Height));
            this.clyde = new Clyde(GameTexture.PacmanAndGhost, new Rectangle(0, 0, Global.quad_Width, Global.quad_Height));
            this.inky = new Inky(GameTexture.PacmanAndGhost, new Rectangle(0, 0, Global.quad_Width, Global.quad_Height));
            this.pinky = new Pinky(GameTexture.PacmanAndGhost, new Rectangle(0, 0, Global.quad_Width, Global.quad_Height));

            this.ghosts.Add(nameof(Blinky), this.blinky);
            this.ghosts.Add(nameof(Clyde), this.clyde);
            this.ghosts.Add(nameof(Inky), this.inky);
            this.ghosts.Add(nameof(Pinky), this.pinky);

            foreach (var kvp in this.ghosts)
            {
                this.PlaceOnRandomXY(kvp.Value, levelMatrix);
            }
            return this.ghosts;
        }

        private void PlaceOnRandomXY(Ghost ghost, Matrix levelMatrix)
        {
            string[] placeAvailable = this.AvailableXY(levelMatrix).Split();
            int placeGhostX = int.Parse(placeAvailable[0]);
            int placeGhostY = int.Parse(placeAvailable[1]);
            ghost.X = placeGhostX * Global.quad_Width;
            ghost.Y = placeGhostY * Global.quad_Height;
            ghost.UpdateBoundingBox();
        }

        private string AvailableXY(Matrix levelMatrix)
        {
          var ghostCoordinates = this.ghosts.Select(g => g.Value);
          while (true)
            {
                int tryX = new Random(DateTime.Now.Millisecond).Next(3, Global.XMax - 1);
                int tryY = new Random(DateTime.Now.Millisecond).Next(3, Global.YMax - 1);
                var pointQuadrant = levelMatrix.Level.LevelCoordinates.FirstOrDefault(coordinate=>coordinate.QuadrantX==tryX && coordinate.QuadrantY==tryY);
                
                if (pointQuadrant != null && !pointQuadrant.isWall && ghostCoordinates.Count(g => g.X == tryX * Global.quad_Width && g.Y == tryY * Global.quad_Height) == 0)
                {
                   return $"{tryX} {tryY}";
                }
            }
        }

        private Dictionary<string, Animator> AddAnimators(PacMan pacMan)
        {
            this.animationModels.Add(nameof(Blinky), new BlinkyAnimator(this.blinky));
            this.animationModels.Add(nameof(Clyde), new ClydeAnimator(this.clyde));
            this.animationModels.Add(nameof(Inky), new InkyAnimator(this.inky));
            this.animationModels.Add(nameof(Pinky), new PinkyAnimator(this.pinky));
            this.animationModels.Add(nameof(PacMan), new PacmanAnimator(pacMan));
            return this.animationModels;
        }

        private Dictionary<string, IMovable> AddMovements(Matrix levelMatrix, PacMan pacMan)
        {
            this.movableModels.Add(nameof(Blinky), new GhostRandomMovement(this.blinky, levelMatrix, pacMan));
            this.movableModels.Add(nameof(Clyde), new GhostRandomMovement(this.clyde, levelMatrix, pacMan));
            this.movableModels.Add(nameof(Inky), new GhostHuntingRandomMovement(this.inky, levelMatrix, pacMan));
            this.movableModels.Add(nameof(Pinky), new GhostHuntingRandomMovement(this.pinky, levelMatrix, pacMan));
            this.movableModels.Add(nameof(PacMan), new PacmanInputHandler(pacMan, levelMatrix));
            return this.movableModels;
        }

        public void Dispose()
        {
            this.ghosts.Clear();
            this.animationModels.Clear();
            this.movableModels.Clear();
        }
    }
}