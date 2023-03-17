using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Collisions
{
    public class Panel
    {
        public Vector2 position;
        public int speedX;
        public float transparency;
        public bool panelStop;
        public Color panelColor;
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D img;
        List<Panel> listPanel;
        Random rnd;
        MouseState lastState;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            listPanel = new List<Panel>();
            rnd = new Random();

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
            img = this.Content.Load<Texture2D>("metalPanel");

            for (int i = 0; i < 20; i++)
            {
                Panel myPanel = new Panel();
                int x = rnd.Next(0, GraphicsDevice.Viewport.Width - img.Width);
                int y = rnd.Next(0, GraphicsDevice.Viewport.Height -img.Height);
                myPanel.position = new Vector2(x, y);
                myPanel.speedX = rnd.Next(1,5);
                myPanel.transparency = 0.5f;
                myPanel.panelStop = false;
                myPanel.panelColor = Color.White;
                listPanel.Add(myPanel);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            MouseState newState = Mouse.GetState();
            bool bClick = false;
            if (newState.LeftButton == ButtonState.Pressed && lastState.LeftButton == ButtonState.Released)
            {
                Console.WriteLine("Click!");
                bClick = true;
            }
            lastState = newState;
            bool collideImg = false;
            for (int i = listPanel.Count -1 ; i >= 0; i--)
            {
                Panel item = listPanel[i];
                if (item.position.X + img.Width > GraphicsDevice.Viewport.Width)
                {
                    item.speedX = -item.speedX;
                }
                else if (item.position.X < 0)
                {
                    item.speedX = -item.speedX;
                }
                item.position.X += item.speedX;
                if (bClick && collideImg == false)
                {
                    if (newState.X >= item.position.X &&
                        newState.X <= item.position.X + img.Width &&
                        newState.Y >= item.position.Y &&
                        newState.Y <= item.position.Y + img.Height)
                    {
                        collideImg = true;
                        if (item.panelStop == false)
                        {
                            item.panelStop = true;
                            item.speedX = 0;
                            item.panelColor = Color.Red;
                        }
                        else
                        {
                            item.panelStop = false;
                            item.speedX = rnd.Next(1, 5);
                            item.panelColor = Color.White;
                        }
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            SpriteEffects effect;
            foreach (Panel item in listPanel)
            {
                effect = SpriteEffects.None;
                _spriteBatch.Draw(img, item.position, null, item.panelColor * item.transparency, 0, Vector2.Zero, 1.0f, effect, 0);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}