using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AugustoGamesAndroid.GamePlay.Players
{
    public class Enemy
    {
        public Vector2 Position { get; set; }
        protected Vector2 StartPosition { get; set; }
        public Texture2D Texture { get; set; }

        public Enemy(Vector2 position, Texture2D texture)
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
            float speed = 50f;
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
