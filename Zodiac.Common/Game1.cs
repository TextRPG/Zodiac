using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zodiac.Common.UI;

namespace Zodiac.Common
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D tex;
        RenderTarget2D renderTarget;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.SupportedOrientations = DisplayOrientation.Portrait;

#if __MOBILE__
            graphics.IsFullScreen = true;
#else
            graphics.PreferredBackBufferWidth = 360;
            graphics.PreferredBackBufferHeight = 640;
#endif

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            renderTarget = new RenderTarget2D(GraphicsDevice, 720, 1280);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tex = Content.Load<Texture2D>("char");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            /*spriteBatch.Begin();
            spriteBatch.Draw(tex, Vector2.Zero, Color.White);
            spriteBatch.End();*/

            var rect = new Image { Left = 50, Top = 50, Width = 100, Height = 200, Background = Color.Gray, Texture = tex };
            rect.Draw(spriteBatch);

            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin();
            spriteBatch.Draw(renderTarget, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
