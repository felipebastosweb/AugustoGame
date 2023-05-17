using Microsoft.Xna.Framework;

using Engine2D.Entities;

namespace Engine2D.Cameras
{

    public class Camera
    {
        public Vector2 Position { get; set; }
        public int ViewportWidth { get; set; }
        public int ViewportHeight { get; set; }

        public Camera(int viewportWidth, int viewportHeight)
        {
            ViewportWidth = viewportWidth;
            ViewportHeight = viewportHeight;
        }

        public void Follow(Hero player, int mapWidth, int mapHeight, int tileSize)
        {
            float cameraX = player.CurrentPosition.X - ViewportWidth / 2;
            float cameraY = player.CurrentPosition.Y - ViewportHeight / 2;

            if (cameraX < 0)
                cameraX = 0;

            if (cameraY < 0)
                cameraY = 0;

            if (cameraX > mapWidth * tileSize - ViewportWidth)
                cameraX = mapWidth * tileSize - ViewportWidth;

            if (cameraY > mapHeight * tileSize - ViewportHeight)
                cameraY = mapHeight * tileSize - ViewportHeight;

            Position = new Vector2(cameraX, cameraY);
        }

        // TODO: pedir para o Bing Chat criar novamente o método Follow da Câmera
        // para seguir o player apenas quando ele estiver a 2 tiles de distância do final da zona de visualização da câmera
        // evitando assim que fique atualizando a tela diversas vezes, deixando o jogo lento
    }

}
