﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

using AugustoGamesAndroid.GamePlay;
using AugustoGamesAndroid.GamePlay.Players;
using Java.Util;
using AugustoGamesAndroid.GamePlay.TileSets;

/***
 * Top Down Scene
 * https://cainos.itch.io/pixel-art-top-down-basic
 * https://opengameart.org/
 * https://craftpix.net/freebies/top-down-crystals-pixel-art/
 * https://craftpix.net/freebies/free-top-down-military-boats-pixel-art/
 * **/

namespace AugustoGamesAndroid.GamePlay.Scenes
{
    public class FirstScene
    {
        public int tileSize = 64;
        
        private int[,] tileMap = new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 2, 0, 1 },
            { 1, 0, 2, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 2, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 2, 0, 1 },
            { 1, 0, 2, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 2, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };

        private Game1 Game;
        private Dictionary<int, Texture2D> tileTextures;
        private SpriteBatch spriteBatch;

        private Player player;
        private List<Enemy> enemies;

        private int score;
        private SpriteFont font;

        private FirstSceneTileSet tileSet;
        public FirstScene(Game1 Game, SpriteBatch spriteBatch, Dictionary<int, Texture2D> tileTextures)
        {
            var Content = Game.Content;
            this.spriteBatch = spriteBatch;
            this.tileTextures = tileTextures;

            // Inicialize o jogador
            Texture2D playerTexture = Content.Load<Texture2D>("player");
            player = new Player(new Vector2(100, 100), playerTexture);

            // Inicialize os inimigos
            enemies = new List<Enemy>();
            Texture2D enemyTexture = Content.Load<Texture2D>("enemy");
            for (int i = 0; i < 3; i++)
            {
                Enemy enemy = new Enemy(new Vector2(200 + i * 100, 200), enemyTexture);
                enemies.Add(enemy);
            }

            // TODO: Inicializa o TileSet
            //tileSet = new FirstSceneTileSet(tileMap);

            // Inicialize a fonte
            font = Content.Load<SpriteFont>("font");
        }

        public void Draw()
        {
            spriteBatch.Begin();

            /*
             Para adicionar a câmera ao arquivo FirstScene.cs, você pode instanciar a classe Camera
             e passá-la como parâmetro para o método Draw da classe FirstSceneTileSet.
            Você também pode adicionar o controle de câmera à cena atualizando a posição da
            câmera com base na posição do jogador. Por exemplo:
             */

            // TODO: Desenho do mapa usando a classe TileSet .. colocar para a câmera seguir o jogador
            // Instancie a câmera no construtor da classe FirstScene
            var camera = new Camera(Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);

            // Atualize a posição da câmera com base na posição do jogador no método Update
            camera.Follow(player, tileMap.GetLength(0), tileMap.GetLength(1), tileSize);

            // Passe a câmera como parâmetro para o método Draw da classe FirstSceneTileSet
            tileSet.Draw(spriteBatch, camera);


            // Desenhe o mapa de tiles
            for (int y = 0; y < tileMap.GetLength(0); y++)
            {
                for (int x = 0; x < tileMap.GetLength(1); x++)
                {
                    int tileValue = tileMap[y, x];
                    Texture2D tileTexture = tileTextures[tileValue];
                    Vector2 position = new Vector2(x * tileSize, y * tileSize);
                    spriteBatch.Draw(tileTexture, position, Color.White);
                }
            }

            // Desenhe o jogador
            player.Draw(spriteBatch);

            // Desenhe os inimigos
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }

            // Desenhe a pontuação do jogador
            string scoreText = "Score: " + score;
            Vector2 scorePosition = new Vector2(10, 10);
            spriteBatch.DrawString(font, scoreText, scorePosition, Color.White);

            spriteBatch.End();
        }
    }
}
