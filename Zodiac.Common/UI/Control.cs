using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zodiac.Common.UI
{
    public class Control
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int Left { get; set; } 
        public int Top { get; set; }

        public Color Background { get; set; }

        protected virtual void PreRender(SpriteBatch spriteBatch)
        {
            var pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });

            spriteBatch.Begin();
            spriteBatch.Draw(pixel, new Rectangle(Left, Top, Width, Height), Background);
            spriteBatch.End();
        }

        protected virtual void PostRender(SpriteBatch spriteBatch)
        {

        }

        protected virtual void Render(SpriteBatch spriteBatch)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            PreRender(spriteBatch);
            Render(spriteBatch);
            PostRender(spriteBatch);
        }
    }
}
