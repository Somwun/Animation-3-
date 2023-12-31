﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Animation__3_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _greyTribble, _orangeTribble, _brownTribble, _creamTribble, _tribbleIntro;
        Rectangle greyTribbleRect, orangeTribbleRect, brownTribbleRect, creamTribbleRect, introRect;
        Vector2 greyTribbleSpeed, orangeTribbleSpeed, brownTribbleSpeed, creamTribbleSpeed;
        SpriteFont _introText;
        private bool gray = false, orange = false, brown = false, cream = false;
        private int bounces = 0;
        Color backColor = Color.White;
        Random generator = new Random();
        SoundEffect _tribbleCoo;
        MouseState mouseState;
        enum Screen
        {
            Intro,
            TribbleYard
        }
        Screen screen = Screen.Intro;

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
            greyTribbleRect = new Rectangle(generator.Next(1, 690), generator.Next(1, 390), 100, 100);
            orangeTribbleRect = new Rectangle(generator.Next(1, 690), generator.Next(1, 390), 100, 100);
            brownTribbleRect = new Rectangle(generator.Next(1, 690), generator.Next(1, 390), 100, 100);
            creamTribbleRect = new Rectangle(generator.Next(1, 690), generator.Next(1, 390), 100, 100);
            introRect = new Rectangle (0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

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
            _tribbleCoo = Content.Load<SoundEffect>("tribble_coo");
            _tribbleIntro = Content.Load<Texture2D>("tribble_intro");
            _introText = Content.Load<SpriteFont>("Intro");
        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (bounces >= 20)
            {
                screen = Screen.Intro;
                bounces = 0;
            }
            mouseState = Mouse.GetState();
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;
            }
            else if (screen == Screen.TribbleYard)
            {
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
                    bounces++;
                    _tribbleCoo.Play();
                }
                if (greyTribbleRect.Bottom >= _graphics.PreferredBackBufferHeight || greyTribbleRect.Top <= 0)
                {
                    greyTribbleSpeed.Y *= -1;
                    backColor = Color.Gray;
                    bounces++;
                    _tribbleCoo.Play();
                }
                //Orange
                if (orangeTribbleRect.Right >= _graphics.PreferredBackBufferWidth || orangeTribbleRect.Left <= 0)
                {
                    if (generator.Next(1,3) == 1)
                        orangeTribbleSpeed.X *= -1;
                    orangeTribbleRect.X = generator.Next(1, 699);
                    orangeTribbleRect.Y = generator.Next(1, 399);
                    backColor = Color.DarkOrange;
                    bounces++;
                    _tribbleCoo.Play();
                }
                if (orangeTribbleRect.Bottom >= _graphics.PreferredBackBufferHeight || orangeTribbleRect.Top <= 0)
                {
                    if (generator.Next(1, 3) == 1)
                        orangeTribbleSpeed.Y *= -1;
                    orangeTribbleRect.X = generator.Next(1, 699);
                    orangeTribbleRect.Y = generator.Next(1, 399);
                    backColor = Color.DarkOrange;
                    bounces++;
                    _tribbleCoo.Play();
                }
                //Cream
                if (creamTribbleRect.Top >= _graphics.PreferredBackBufferHeight)
                {
                    creamTribbleRect.Y = -100;
                    backColor = Color.AntiqueWhite;
                    bounces++;
                    _tribbleCoo.Play();
                }
                else if (creamTribbleRect.Bottom <= -100)
                {
                    creamTribbleRect.Y = _graphics.PreferredBackBufferHeight;
                    backColor = Color.AntiqueWhite;
                    bounces++;
                    _tribbleCoo.Play();
                }
                if (creamTribbleRect.Right >= _graphics.PreferredBackBufferWidth || creamTribbleRect.Left <= 0)
                {
                    creamTribbleSpeed.X *= -1;
                    backColor = Color.AntiqueWhite;
                    bounces++;
                    _tribbleCoo.Play();
                }
                //Brown
                if (brownTribbleRect.Left >= _graphics.PreferredBackBufferWidth)
                {
                    backColor = Color.SaddleBrown;
                    brownTribbleRect.X = -100;
                    bounces++;
                    _tribbleCoo.Play();
                }
                else if (brownTribbleRect.Right <= -100)
                {
                    backColor = Color.SaddleBrown;
                    brownTribbleRect.X = _graphics.PreferredBackBufferWidth;
                    bounces++;
                    _tribbleCoo.Play();
                }
                if (brownTribbleRect.Top >= _graphics.PreferredBackBufferHeight)
                {
                    backColor = Color.SaddleBrown;
                    brownTribbleRect.Y = -100;
                    bounces++;
                    _tribbleCoo.Play();
                }
                else if (brownTribbleRect.Bottom <= -100)
                {
                    backColor = Color.SaddleBrown;
                    brownTribbleRect.Y = _graphics.PreferredBackBufferHeight;
                    bounces++;
                    _tribbleCoo.Play();
                }
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backColor);
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(_tribbleIntro, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
                _spriteBatch.DrawString(_introText, "Click to Tribble it up", new Vector2(0, 250), Color.Black);
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(_greyTribble, greyTribbleRect, Color.White);
                _spriteBatch.Draw(_orangeTribble, orangeTribbleRect, Color.White);
                _spriteBatch.Draw(_brownTribble, brownTribbleRect, Color.White);
                _spriteBatch.Draw(_creamTribble, creamTribbleRect, Color.White);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}