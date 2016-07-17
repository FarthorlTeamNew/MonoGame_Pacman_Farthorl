using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine.Menu
{
    public class CButton
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;

        Color color = new Color(255, 255, 255, 255);
        public Vector2 size;

        public CButton(Texture2D newTexture, GraphicsDevice graphics)
        {
            this.texture = newTexture;
            this.size = new Vector2(graphics.Viewport.Width / 8, graphics.Viewport.Height / 20);
        }

        bool down;
        public bool isClicked;

        public void Update(MouseState mouseState)
        {
            this.rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, (int)this.size.X, (int)this.size.Y);
            Rectangle mouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);

            if (mouseRectangle.Intersects(this.rectangle))
            {
                if (this.color.A == 255) this.down = false;
                if (this.color.A == 0) this.down = true;
                if (this.down) this.color.A += 3; else this.color.A -= 3;
                if (mouseState.LeftButton == ButtonState.Pressed) this.isClicked = true;

            }
            else if (this.color.A < 255)
            {
                this.color.A += 3;
                this.isClicked = false;
            }
        }

        public void SetPosition(Vector2 newPosition)
        {
            this.position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.rectangle, this.color);
        }
    }
}
