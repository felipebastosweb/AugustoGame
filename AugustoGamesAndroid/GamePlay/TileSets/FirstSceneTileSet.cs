using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using AugustoGamesAndroid.GamePlay.Scenes;
using AugustoGamesAndroid.GamePlay.Players;
using Java.Util;

namespace AugustoGamesAndroid.GamePlay.TileSets
{

    public class FirstSceneTileSet
    {
        private Texture2D tilesetTexture;
        private int tileWidth;
        private int tileHeight;
        private int[,] map;

        // TODO: tornar a inicialização do tileSet independente da classe FirstScene
        public FirstSceneTileSet(Texture2D tilesetTexture, int tileWidth, int tileHeight, int[,] map)
        {
            this.tilesetTexture = tilesetTexture;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.map = map;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    int tileIndex = map[x, y];
                    int tilesetColumn = tileIndex % (tilesetTexture.Width / tileWidth);
                    int tilesetRow = tileIndex / (tilesetTexture.Width / tileWidth);

                    Rectangle sourceRectangle = new Rectangle(tilesetColumn * tileWidth, tilesetRow * tileHeight, tileWidth, tileHeight);
                    Vector2 position = new Vector2(x * tileWidth - camera.Position.X, y * tileHeight - camera.Position.Y);

                    spriteBatch.Draw(tilesetTexture, position, sourceRectangle, Color.White);
                }
            }
        }
    }
}
