using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine2D.Entities
{
    public class Sprite : Component
    {
        const int tileSize = 64;
        protected Vector2 StartPosition { get; set; }
        public Texture2D Texture { get; set; }
        public float speed = 50f;

        public Sprite(Vector2 position, Texture2D texture)
        {
            Position = position;
            StartPosition = position;
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
        public void Update(GameTime gameTime, Vector2 playerPosition)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float distanceToPlayer = Vector2.Distance(Position, playerPosition);
            float distanceToStart = Vector2.Distance(Position, StartPosition);

            if (distanceToPlayer <= 2 * tileSize && distanceToStart <= 3 * tileSize)
            {
                // Siga o jogador
                Vector2 direction = playerPosition - Position;
                direction.Normalize();
                Position += direction * speed * deltaTime;
            }
            else if (distanceToStart > 3 * tileSize)
            {
                // Volte para a posição inicial
                Vector2 direction = StartPosition - Position;
                direction.Normalize();
                Position += direction * speed * deltaTime;
            }
        }

    }
}
