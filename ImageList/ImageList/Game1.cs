using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace ImageList
{
    public class Jelly
    {
        public Vector2 position;
        public int speedX;
        public float scale;
        public float scaleSpeed;
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D img;
        List<Jelly> listJelly;
        Random rnd;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            listJelly = new List<Jelly>();
            rnd = new Random();
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
            img = this.Content.Load<Texture2D>("slimePurple2");

            for (int i = 0; i < 2000; i++)
            {
                Jelly myJelly = new Jelly();
                int x = rnd.Next(img.Width, GraphicsDevice.Viewport.Width);
                int y = rnd.Next(0, GraphicsDevice.Viewport.Height);
                myJelly.position = new Vector2(x, y);
                myJelly.speedX = rnd.Next(1, 5);
                myJelly.scale = 1.0f;
                myJelly.scaleSpeed = -0.01f;
                listJelly.Add(myJelly);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (Jelly item in listJelly)
            {
                if (item.position.X > GraphicsDevice.Viewport.Width)
                {
                    item.speedX = -item.speedX;
                }
                else if (item.position.X < 0)
                {
                    item.speedX = -item.speedX;
                }
                item.position.X += item.speedX;
                if (item.scale < 0.5f)
                {
                    item.scale = 0.5f;
                    item.scaleSpeed = -item.scaleSpeed;
                }
                else if (item.scale > 1.0f)
                {
                    item.scale = 1.0f;
                    item.scaleSpeed = -item.scaleSpeed;
                }
                item.scale += item.scaleSpeed;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            SpriteEffects effect;
            foreach (Jelly item in listJelly)
            {
                effect = SpriteEffects.None;
                if (item.speedX >= 0)
                    effect = SpriteEffects.FlipHorizontally;
                _spriteBatch.Draw(img, item.position, null, Color.White, 0, new Vector2(img.Width / 2, img.Height), new Vector2(item.scale, item.scale), effect, 0);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}