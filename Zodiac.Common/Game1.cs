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

        Texture2D villageBg;
        Texture2D waterHouseBg;

        SpriteFont header;
        SpriteFont listItem;

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
            villageBg = Content.Load<Texture2D>("village_bg");
            waterHouseBg = Content.Load<Texture2D>("water_house_bg");
            header = Content.Load<SpriteFont>("header");
            listItem = Content.Load<SpriteFont>("list_item");
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

            var label = new Label {
                Left = 0, Top = 0,
                Width = 720, Height = 75,
                Background = new Color(27, 38, 44),
                Caption = "Village",
                Color = new Color(187, 225, 250),
                Font = header };
            label.Draw(spriteBatch);

            var image = new Image { Left = 0, Top = label.Height, Width = 720, Height = 450, Background = Color.Transparent, Texture = villageBg };
            image.Draw(spriteBatch);

            var items = new[]
            {
                "Waterhouse",
                "Field",
                "My house"
            };

            var itemSeprator = new Control { Left = 0, Top = image.Top + image.Height, Width = 720, Height = 10, Background = new Color(50, 130, 184) };
            itemSeprator.Draw(spriteBatch);
            var itemControl = new Control { Left = 0, Top = itemSeprator.Top + itemSeprator.Height, Width = 720, Height = 100, Background = new Color(15, 76, 117)};
            itemSeprator.Top += itemSeprator.Height + itemControl.Height;

            for (int i = 0; i < items.Length; ++i)
            {
                itemControl.Draw(spriteBatch);
                itemSeprator.Draw(spriteBatch);

                var text = new Label
                {
                    Left = 0,
                    Top = itemControl.Top,
                    Width = 720,
                    Height = itemControl.Height,
                    Background = Color.Transparent,
                    Caption = items[i],
                    Color = new Color(187, 225, 250),
                    Font = listItem
                };
                text.Draw(spriteBatch);

                itemControl.Top += itemControl.Height + itemSeprator.Height;
                itemSeprator.Top += itemControl.Height + itemSeprator.Height;
            }


            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin();
            spriteBatch.Draw(renderTarget, GraphicsDevice.Viewport.Bounds, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
