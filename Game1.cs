using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Animation__3_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _greyTribble, _orangeTribble, _brownTribble, _creamTribble;
        Rectangle greyTribbleRect, orangeTribbleRect, brownTribbleRect, creamTribbleRect;
        Vector2 greyTribbleSpeed, orangeTribbleSpeed, brownTribbleSpeed, creamTribbleSpeed;
        private bool gray = false, orange = false, brown = false, cream = false;
        Color backColor = Color.White;
        Random generator = new Random();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.ApplyChanges();

            greyTribbleRect = new Rectangle(generator.Next(1, 800), generator.Next(1, 500), 100, 100);
            orangeTribbleRect = new Rectangle(generator.Next(1, 800), generator.Next(1, 500), 100, 100);
            brownTribbleRect = new Rectangle(generator.Next(1, 800), generator.Next(1, 500), 100, 100);
            creamTribbleRect = new Rectangle(generator.Next(1, 800), generator.Next(1, 500), 100, 100);

            greyTribbleSpeed = new Vector2(3, 3);
            orangeTribbleSpeed = new Vector2(2, 4);
            brownTribbleSpeed = new Vector2(6, 0);
            creamTribbleSpeed = new Vector2(0, 6);

            this.Window.Title = "Animation";
            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _greyTribble = Content.Load<Texture2D>("tribbleGrey");
            _orangeTribble = Content.Load<Texture2D>("tribbleOrange");
            _brownTribble = Content.Load<Texture2D>("tribbleBrown");
            _creamTribble = Content.Load<Texture2D>("tribbleCream");
        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            greyTribbleRect.X += (int)greyTribbleSpeed.X;
            greyTribbleRect.Y += (int)greyTribbleSpeed.Y;
            orangeTribbleRect.X += (int)orangeTribbleSpeed.X;
            orangeTribbleRect.Y += (int)orangeTribbleSpeed.Y;
            brownTribbleRect.X += (int)brownTribbleSpeed.X;
            brownTribbleRect.Y += (int)brownTribbleSpeed.Y;
            creamTribbleRect.X += (int)creamTribbleSpeed.X;
            creamTribbleRect.Y += (int)creamTribbleSpeed.Y;

            //Grey
            if (greyTribbleRect.Right >= _graphics.PreferredBackBufferWidth || greyTribbleRect.Left <= 0)
            {
                greyTribbleSpeed.X *= -1;
                backColor = Color.Gray;
            }
            if (greyTribbleRect.Bottom >= _graphics.PreferredBackBufferHeight || greyTribbleRect.Top <= 0)
            {
                greyTribbleSpeed.Y *= -1;
                backColor = Color.Gray;
            }
            //Orange
            if (orangeTribbleRect.Right >= _graphics.PreferredBackBufferWidth || orangeTribbleRect.Left <= 0)
            {
                if (generator.Next(1,3) == 1)
                    orangeTribbleSpeed.X *= -1;
                orangeTribbleRect.X = generator.Next(1, 699);
                orangeTribbleRect.Y = generator.Next(1, 399);
                backColor = Color.DarkOrange;
            }
            if (orangeTribbleRect.Bottom >= _graphics.PreferredBackBufferHeight || orangeTribbleRect.Top <= 0)
            {
                if (generator.Next(1, 3) == 1)
                    orangeTribbleSpeed.Y *= -1;
                orangeTribbleRect.X = generator.Next(1, 699);
                orangeTribbleRect.Y = generator.Next(1, 399);
                backColor = Color.DarkOrange;
            }
            //Cream
            if (creamTribbleRect.Top >= _graphics.PreferredBackBufferHeight)
            {
                creamTribbleRect.Y = -100;
                backColor = Color.AntiqueWhite;
            }
            else if (creamTribbleRect.Bottom <= -100)
            {
                creamTribbleRect.Y = _graphics.PreferredBackBufferHeight;
                backColor = Color.AntiqueWhite;
            }
            if (creamTribbleRect.Right >= _graphics.PreferredBackBufferWidth || creamTribbleRect.Left <= 0)
            {
                creamTribbleSpeed.X *= -1;
                backColor = Color.AntiqueWhite;
            }
            //Brown
            if (brownTribbleRect.Left >= _graphics.PreferredBackBufferWidth)
            {
                backColor = Color.SaddleBrown;
                brownTribbleRect.X = -100;
            }
            else if (brownTribbleRect.Right <= -100)
            {
                backColor = Color.SaddleBrown;
                brownTribbleRect.X = _graphics.PreferredBackBufferWidth;
            }
            if (brownTribbleRect.Top >= _graphics.PreferredBackBufferHeight)
            {
                backColor = Color.SaddleBrown;
                brownTribbleRect.Y = -100;
            }
            else if (brownTribbleRect.Bottom <= -100)
            {
                backColor = Color.SaddleBrown;
                brownTribbleRect.Y = _graphics.PreferredBackBufferHeight;
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backColor);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_greyTribble, greyTribbleRect, Color.White);
            _spriteBatch.Draw(_orangeTribble, orangeTribbleRect, Color.White);
            _spriteBatch.Draw(_brownTribble, brownTribbleRect, Color.White);
            _spriteBatch.Draw(_creamTribble, creamTribbleRect, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}