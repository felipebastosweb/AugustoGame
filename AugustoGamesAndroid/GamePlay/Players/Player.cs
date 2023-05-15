using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/***
 * https://www.gameart2d.com/freebies.html
 * https://www.gameart2d.com/the-boy---free-sprites.html
 * https://www.gameart2d.com/cute-girl-free-sprites.html
 * https://craftpix.net/freebies/filter/sprites/page/5/
 * https://craftpix.net/freebies/free-warrior-4-direction-character-sprites/
 * https://craftpix.net/freebies/free-citizen-artist-astrologer-4-direction-npc-character-pack/
 * https://craftpix.net/freebies/filter/sprites/page/6/
 * **/

namespace AugustoGamesAndroid.GamePlay.Players
{
    public class Player
    {
        public Vector2 Position { get; set; }
        public Vector2? TouchPosition { get; set; }
        public Texture2D Texture { get; set; }

        public Player(Vector2 position, Texture2D texture)
        {
            Position = position;
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            float speed = 100f;
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (TouchPosition.HasValue)
            {
                Vector2 direction = TouchPosition.Value - Position;
                if (direction.Length() > speed * deltaTime)
                {
                    direction.Normalize();
                    Position += direction * speed * deltaTime;
                }
                else
                {
                    Position = TouchPosition.Value;
                    TouchPosition = null;
                }
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                Position = new Vector2(Position.X - speed * deltaTime, Position.Y);
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                Position = new Vector2(Position.X + speed * deltaTime, Position.Y);
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                Position = new Vector2(Position.X, Position.Y - speed * deltaTime);
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                Position = new Vector2(Position.X, Position.Y + speed * deltaTime);
            }
        }
    }
}
