using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AugustoGamesShared.GameEngine.Entities
{
    public class Sprite : Component
    {
        const int tileSize = 64;
        public Vector2 CurrentPosition { get; set; }
        protected Vector2 StartPosition { get; set; }
        public Texture2D CurrentTexture { get; set; }
        public float speed = 50f;

        public Sprite(Vector2 position, Texture2D texture)
        {
            CurrentPosition = position;
            StartPosition = position;
            CurrentTexture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CurrentTexture, CurrentPosition, Color.White);
        }
        public void Update(GameTime gameTime, Vector2 playerPosition)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float distanceToPlayer = Vector2.Distance(CurrentPosition, playerPosition);
            float distanceToStart = Vector2.Distance(CurrentPosition, StartPosition);

            if (distanceToPlayer <= 2 * tileSize && distanceToStart <= 3 * tileSize)
            {
                // Siga o jogador
                Vector2 direction = playerPosition - CurrentPosition;
                direction.Normalize();
                CurrentPosition += direction * speed * deltaTime;
            }
            else if (distanceToStart > 3 * tileSize)
            {
                // Volte para a posição inicial
                Vector2 direction = StartPosition - CurrentPosition;
                direction.Normalize();
                CurrentPosition += direction * speed * deltaTime;
            }
        }

    }
}
