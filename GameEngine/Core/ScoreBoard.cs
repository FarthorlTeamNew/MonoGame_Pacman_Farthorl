namespace GameEngine
{
    using Globals;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Models;

    public static class ScoreBoard
    {
        public static void LoadBoard(PacMan pacMan, SpriteBatch spriteBatch, Game game, SpriteFont font, Matrix levelMatrix)
        {
            var scoreBackground = game.Content.Load<Texture2D>("ScoresBackground");

            spriteBatch.Draw(scoreBackground, new Vector2(0, 416));
            var scores =
                $"Scores: {pacMan.Scores}   " +
                $"Left points: {levelMatrix.LeftPoints}  " +
                $"Health: {pacMan.Health}  " +
                $"Lives: {pacMan.Lives}      ";
            if (pacMan.CanEat)
            {
                scores += $"Eat Ghosts : {5 - Global.GhostKillerTimer.ElapsedMilliseconds/1000}";
            }

            spriteBatch.DrawString(font, scores, new Vector2(15, 426), Color.Aqua);
        }
    }
}