using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_lesson_2___Assignment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window, blackSquares, whiteSquares;

        Texture2D squareTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 800);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            squareTexture = Content.Load<Texture2D>("square");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            for (int y = 0; y <= 10; y++)
            {
                for (int x = 0; x <= 10; x++)
                {
                    if (y % 2 != 0) //Checks for odd numbers
                    {
                        blackSquares = new Rectangle(((x * 200) + 100), y * 100, 100, 100);
                    }
                    else
                    {
                        blackSquares = new Rectangle(x * 200, y * 100, 100, 100);
                    }

                    _spriteBatch.Draw(squareTexture, blackSquares, Color.Black);

                }

                for (int x = 0; x <= 10; x++)
                {
                    if (y == 2 || y == 4 || y == 6 || y == 8)
                    {
                        whiteSquares = new Rectangle(x * 200, ((y * 100) - 100), 100, 100);
                    }
                    else
                    {
                        whiteSquares = new Rectangle(((x * 200) + 100), ((y * 100) - 100), 100, 100);
                    }

                    _spriteBatch.Draw(squareTexture, whiteSquares, Color.White);
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
