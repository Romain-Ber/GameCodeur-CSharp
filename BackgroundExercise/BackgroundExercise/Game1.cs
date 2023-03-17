using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BackgroundExercise
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D texture0;
        private Texture2D texture1;
        private Texture2D texture2;
        private Texture2D texture3;

        private Background background0;
        private Background background1;
        private Background background2;
        private Background background3;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            texture0 = Content.Load<Texture2D>("urban_scrolling0");
            texture1 = Content.Load<Texture2D>("urban_scrolling1");
            texture2 = Content.Load<Texture2D>("urban_scrolling2");
            texture3 = Content.Load<Texture2D>("urban_scrolling3");

            background0 = new Background(texture0, -1);
            background1 = new Background(texture1, -4);
            background2 = new Background(texture2, -3);
            background3 = new Background(texture3, -2);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            background0.Update();
            background1.Update();
            background2.Update();
            background3.Update();

            base.Update(gameTime);
        }
        private void drawBackground(Background pBackground)
        {
            _spriteBatch.Draw(pBackground.Texture, pBackground.Position, Color.White);
            if (pBackground.Position.X < 0)
                _spriteBatch.Draw(pBackground.Texture, new Vector2(pBackground.Position.X + pBackground.Texture.Width, 0), Color.White);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            drawBackground(background0);
            drawBackground(background3);
            drawBackground(background2);
            drawBackground(background1);
            
           
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}