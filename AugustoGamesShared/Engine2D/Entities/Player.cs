using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Engine2D.Animations;
using Engine2D.SpriteSheets;

namespace Engine2D.Entities
{
    public class Player : Sprite
    {
        public Vector2 Position { get; set; }
        
        // Variáveis para movimento
        private Vector2 _velocity;
        private float _speed = 2f;
        
        public Vector2? TouchPosition { get; set; }

        public Texture2D Texture { get; set; }

        private Dictionary<string, SpriteSheet> SpriteSheets;
        private Dictionary<string, PlayerAnimation> Animations;

        public Player(Vector2 position, Texture2D texture) : base(position, texture)
        {
            Position = position;
            Texture = texture;
            SpriteSheets = new Dictionary<string, SpriteSheet>();
            Animations = new Dictionary<string, PlayerAnimation>();
        }

        public void AddAnimation(string title, PlayerAnimation playerAnimation)
        {
            Animations.Add(title, playerAnimation);
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

    public class PlayerAnimated
    {
        // Variáveis para animação e spritesheet
        private Vector2 _position;

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
