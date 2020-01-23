using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zodiac.Common.UI
{
    public class Label : Control
    {
        public SpriteFont Font { get; set; }

        public string Caption { get; set; }

        public Color Color { get; set; }

        protected override void Render(SpriteBatch spriteBatch)
        {
            var sz = Font.MeasureString(Caption);
            spriteBatch.Begin();
            spriteBatch.DrawString(Font, Caption, new Vector2(Left + (Width - sz.X) / 2f, Top + (Height - sz.Y) / 2f), Color);
            spriteBatch.End();
        }
    }
}
