using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zodiac.Common.UI
{
    public class Image : Control
    {
        public Texture2D Texture { get; set; }

        protected override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle(Left, Top, Width, Height), new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White);
            spriteBatch.End();
        }
    }
}
