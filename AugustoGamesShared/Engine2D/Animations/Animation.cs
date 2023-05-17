using Microsoft.Xna.Framework;


namespace Engine2D.Animations
{
    public class Animation
    {
        private int _currentFrame;
        private float _timer;
        private float _interval = 100;

        public int CurrentFrame
        {
            get { return _currentFrame; }
            set { _currentFrame = value; }
        }

        public Animation(int currentFrame)
        {
            _currentFrame = currentFrame;
        }

        public void Update(GameTime gameTime)
        {
            // Atualiza o timer de acordo com o tempo do jogo
            _timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            // Se o timer for maior que o intervalo de tempo entre os frames da animação
            if (_timer > _interval)
            {
                // Atualiza o frame atual da animação
                if (_currentFrame < 3)
                    ++_currentFrame;
                else
                    _currentFrame = 0;

                // Reseta o timer
                _timer = 0f;
            }
        }
    }
}
