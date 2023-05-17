using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;

using AugustoGamesShared.GamePlay.Entities;
using AugustoGamesShared.GamePlay.Scenes;

/***
 * https://craftpix.net/freebies/
 * https://craftpix.net/freebies/page/2/
 * https://craftpix.net/freebies/free-level-map-pixel-art-assets-pack/
 * **/

namespace AugustoGamesShared.GamePlay
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //private FirstScene firstScene;

        private Player player;
        private List<Sprite> enemies;

        public Game1()
        {
            // TODO: inicializa o jogo e habilita movimentação pelo toque na tela
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            TouchPanel.EnabledGestures = GestureType.FreeDrag;
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Adicione aqui sua lógica de inicialização

            // TODO: Força que o jogo sempre fique na horizontal
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft
                | DisplayOrientation.LandscapeRight;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Crie um novo SpriteBatch, que pode ser usado para desenhar texturas.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content para carregar aqui o conteúdo do jogo

            // Inicialize o jogador
            Texture2D playerTexture = Content.Load<Texture2D>("player");
            player = new Player(new Vector2(100, 100), playerTexture);

            // Inicialize os inimigos
            enemies = new List<Sprite>();
            Texture2D enemyTexture = Content.Load<Texture2D>("enemy");
            for (int i = 0; i < 3; i++)
            {
                Sprite enemy = new Enemy(new Vector2(200 + i * 100, 200), enemyTexture);
                enemies.Add(enemy);
            }

            /*
            // Inicialize a primeira cena
            Dictionary<int, Texture2D> tileTextures = new Dictionary<int, Texture2D>();
            tileTextures.Add(0, Content.Load<Texture2D>("empty_tile"));
            tileTextures.Add(1, Content.Load<Texture2D>("wall_tile"));
            tileTextures.Add(2, Content.Load<Texture2D>("floor_tile"));
            firstScene = new FirstScene(this, spriteBatch, tileTextures);
            */

        }
        protected override void UnloadContent()
        {
            // TODO: Descarregue aqui todo o conteúdo que não for ContentManager
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Atualize o jogador
            player.Update(gameTime);

            // Atualize os inimigos
            foreach (Sprite enemy in enemies)
            {
                enemy.Update(gameTime, player.Position);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            // TODO: [BUG] testando o desenho dos jogadores de forma temporária até remover bugs de load de assets
            player.Draw(spriteBatch);
            foreach(var enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }

            // TODO: [Bug] (desabilitado para correção de bug) Desenhe a primeira cena
            //firstScene.Draw();

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
