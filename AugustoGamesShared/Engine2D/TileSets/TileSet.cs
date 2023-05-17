using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Engine2D.Entities;

namespace Engine2D.TileSets
{

    public class TileSet
    {
        public int tileSize = 64;
        public int[,] map;
        // TODO: tornar a inicialização do tileSet independente da classe FirstScene
        public TileSet(int lines, int columns)
        {
            this.map = new int[lines, columns];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    int tileIndex = map[x, y];
                    /*
                    int tilesetColumn = tileIndex % (tilesetTexture.Width / tileWidth);
                    int tilesetRow = tileIndex / (tilesetTexture.Width / tileWidth);

                    Rectangle sourceRectangle = new Rectangle(tilesetColumn * tileWidth, tilesetRow * tileHeight, tileWidth, tileHeight);
                    Vector2 position = new Vector2(x * tileWidth - camera.Position.X, y * tileHeight - camera.Position.Y);

                    spriteBatch.Draw(tilesetTexture, position, sourceRectangle, Color.White);
                    */
                }
            }
        }
    }
}
