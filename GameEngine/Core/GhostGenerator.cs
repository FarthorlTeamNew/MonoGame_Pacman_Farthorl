namespace GameEngine.Core
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

    public class GhostGenerator
    {
        private Dictionary<string, Ghost> ghosts;
        private Dictionary<string, Animator> ghostAnimators;
        private Dictionary<string, IMovable> ghostMovements;
        private Ghost blinky;
        private Ghost clyde;
        private Ghost inky;
        private Ghost pinky;
        private Random random;

        public GhostGenerator(Matrix levelMatrix, PacMan pacMan)
        {
            this.random = new Random(DateTime.Now.Millisecond);
            this.ghosts = new Dictionary<string, Ghost>();
            this.ghostAnimators = new Dictionary<string, Animator>();
            this.ghostMovements = new Dictionary<string, IMovable>();

            this.Ghosts = this.GetGhosts(levelMatrix);
            this.GhostAnimators = this.GetGhostAnimators(pacMan);
            this.GhostMovements = this.GetGhostMovements(levelMatrix, pacMan);
        }

        public Dictionary<string, Ghost> Ghosts { get; private set; }
        public Dictionary<string, Animator> GhostAnimators { get; private set; }
        public Dictionary<string, IMovable> GhostMovements { get; private set; }

        private Dictionary<string, Ghost> GetGhosts(Matrix levelMatrix)
        {
            this.blinky = new Blinky(GameTexture.PacmanAndGhost, new Rectangle(0, 0, 32, 32));
            this.clyde = new Clyde(GameTexture.PacmanAndGhost, new Rectangle(0, 0, 32, 32));
            this.inky = new Inky(GameTexture.PacmanAndGhost, new Rectangle(0, 0, 32, 32));
            this.pinky = new Pinky(GameTexture.PacmanAndGhost, new Rectangle(0, 0, 32, 32));

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

        private Dictionary<string, Animator> GetGhostAnimators(PacMan pacMan)
        {
            this.ghostAnimators.Add(nameof(Blinky), new BlinkyAnimator(this.blinky));
            this.ghostAnimators.Add(nameof(Clyde), new ClydeAnimator(this.clyde));
            this.ghostAnimators.Add(nameof(Inky), new InkyAnimator(this.inky));
            this.ghostAnimators.Add(nameof(Pinky), new PinkyAnimator(this.pinky));
            this.ghostAnimators.Add(nameof(PacMan), new PacmanAnimator(pacMan));
            return this.ghostAnimators;
        }

        private Dictionary<string, IMovable> GetGhostMovements(Matrix levelMatrix, PacMan pacMan)
        {
            this.ghostMovements.Add(nameof(Blinky), new GhostGoodRandomMovement(this.blinky, levelMatrix, pacMan));
            this.ghostMovements.Add(nameof(Clyde), new GhostGoodRandomMovement(this.clyde, levelMatrix, pacMan));
            this.ghostMovements.Add(nameof(Inky), new GhostHuntingRandomMovement(this.inky, levelMatrix, pacMan));
            this.ghostMovements.Add(nameof(Pinky), new GhostHuntingRandomMovement(this.pinky, levelMatrix, pacMan));
            this.ghostMovements.Add(nameof(PacMan), new PacmanInputHandler(pacMan, levelMatrix));
            return this.ghostMovements;
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
            while (true)
            {
                int tryX = this.random.Next(3, Global.XMax - 1);
                int tryY = this.random.Next(3, Global.YMax - 1);
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