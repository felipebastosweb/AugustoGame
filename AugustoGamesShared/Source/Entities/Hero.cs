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

namespace Engine2D.Entities
{
    public class Hero : Sprite
    {
        public Vector2? TouchPosition { get; set; }

        public Hero(Vector2 position, Texture2D texture) : base(position, texture)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, CurrentPosition, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            float speed = 100f;
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (TouchPosition.HasValue)
            {
                Vector2 direction = TouchPosition.Value - CurrentPosition;
                if (direction.Length() > speed * deltaTime)
                {
                    direction.Normalize();
                    CurrentPosition += direction * speed * deltaTime;
                }
                else
                {
                    CurrentPosition = TouchPosition.Value;
                    TouchPosition = null;
                }
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                CurrentPosition = new Vector2(CurrentPosition.X - speed * deltaTime, CurrentPosition.Y);
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                CurrentPosition = new Vector2(CurrentPosition.X + speed * deltaTime, CurrentPosition.Y);
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                CurrentPosition = new Vector2(CurrentPosition.X, CurrentPosition.Y - speed * deltaTime);
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                CurrentPosition = new Vector2(CurrentPosition.X, CurrentPosition.Y + speed * deltaTime);
            }
        }
    }

    public class PlayerAnimated
    {
        // Variáveis para animação e spritesheet
        private ISpriteSheet _spriteSheet;
        private PlayerAnimation _animation;
        private Vector2 _position;

        // Variáveis para movimento
        private Vector2 _velocity;
        private float _speed = 2f;

        // Propriedades
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Player(PlayerSpriteSheet spriteSheet, PlayerAnimation animation)
        {
            _spriteSheet = spriteSheet;
            _animation = animation;
        }

        public void Update(GameTime gameTime)
        {
            // Movimento do personagem
            Move();

            // Animação do personagem
            Animate(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _spriteSheet.Draw(spriteBatch, Position, _animation.CurrentFrame);
        }

        private void Move()
        {
            KeyboardState kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.Up))
                _velocity.Y = -_speed;
            else if (kState.IsKeyDown(Keys.Down))
                _velocity.Y = _speed;
            else
                _velocity.Y = 0f;

            if (kState.IsKeyDown(Keys.Left))
                _velocity.X = -_speed;
            else if (kState.IsKeyDown(Keys.Right))
                _velocity.X = _speed;
            else
                _velocity.X = 0f;

            // Atualiza a posição do personagem de acordo com o movimento
            Position += _velocity;
        }

        private void Animate(GameTime gameTime)
        {
            // Atualiza a animação do personagem
            _animation.Update(gameTime);
        }
    }
}
