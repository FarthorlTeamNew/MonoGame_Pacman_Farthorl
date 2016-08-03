namespace GameEngine.Core
{
    using Globals;
    using Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public static class ScoreBoard
    {
        public static void LoadBoard(PacMan pacMan, SpriteBatch spriteBatch, Game game, Matrix levelMatrix)
        {
            var scoreBackground = game.Content.Load<Texture2D>("ScoresBackground");

            spriteBatch.Draw(scoreBackground, new Vector2(0, 416));
            var scores =
                $"Scores: {pacMan.Scores}   " +
                $"Left points: {levelMatrix.LeftPoints}  " +
                $"Health: {pacMan.Health}  " +
                $"Lives: {pacMan.Lives}      ";
            if (Global.GhostKillerTimer.ElapsedMilliseconds != 0)
            {
                scores += $"| Eat Ghosts : {5 - Global.GhostKillerTimer.ElapsedMilliseconds / 1000} ";
            }
            if (Global.PeachTimer.ElapsedMilliseconds != 0)
            {
                scores += $"| Sobering up in : {5 - Global.PeachTimer.ElapsedMilliseconds / 1000} ";
            }

            spriteBatch.DrawString(GameTexture.Font, scores, new Vector2(15, 426), Color.Aqua);
        }
    }
}