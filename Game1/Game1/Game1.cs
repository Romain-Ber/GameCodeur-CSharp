using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D img;
        Vector2 position;
        int speedX;
        int speedY;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            position = new Vector2(100, 100);
            speedX = 10;
            speedY = 5;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            img = this.Content.Load<Texture2D>("personnage");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (position.X + img.Width >= GraphicsDevice.Viewport.Width)
            {
                speedX = -speedX;
            }
            else if (position.X <= 0)
            {
                speedX = -speedX;
            }
            position.X += speedX;
            if (position.Y + img.Height >= GraphicsDevice.Viewport.Height)
            {
                speedY = -speedY;
            }
            else if (position.Y <= 0)
            {
                speedY = -speedY;
            }
            position.Y += speedY;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(img, position, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}