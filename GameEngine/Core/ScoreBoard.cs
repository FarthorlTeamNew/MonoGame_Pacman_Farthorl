namespace GameEngine
{
    using System.Net.Mime;
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
                $"Lives: {pacMan.Lives}      " +
                $"Can PacMan eat? : {pacMan.CanEat}";

            spriteBatch.DrawString(font, scores, new Vector2(15, 426), Color.Aqua);
        }
    }
}