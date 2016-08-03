namespace GameEngine.Models.LevelObjects.Ghosts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Pinky : Ghost
    {
        public Pinky(Texture2D texture,  Rectangle boundingBox)
            : base(texture, boundingBox)
        {
        }
    }
}
