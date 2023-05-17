using Engine2D.Levels;
using Engine2D.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Engine2D.Games
{
    public class GameBase : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Menu menu;
        public Dictionary<int, Level> Levels;
        public Level CurrentLevel;

        public GameBase()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            // TODO: Adicione aqui sua lógica de inicialização

            // TODO: Força que o jogo no dispositivo mobile sempre fique na horizontal
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft
                | DisplayOrientation.LandscapeRight;

            // Permite adicionar os levels do jogo
            Levels = new Dictionary<int, Level>();

            base.Initialize();
        }

        protected void InitLoadContent()
        {
            // Crie um novo SpriteBatch, que pode ser usado para desenhar texturas.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //base.LoadContent();
        }

        protected void InitUpdate(GameTime gameTime)
        {
            /*
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            */

            CurrentLevel.Update(gameTime);

            //base.Update(gameTime);
        }
    }
}