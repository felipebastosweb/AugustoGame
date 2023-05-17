using System.Collections.Generic;

using Engine2D.Scenes;
using Engine2D.Entities;
using Microsoft.Xna.Framework;

namespace Engine2D.Levels
{
    public class Level
    {
        public Scene CurrentScene;
        public Dictionary<int, Scene> Scenes;
        public Hero player;
        public Level()
        {
            Scenes = new Dictionary<int, Scene>();
        }

        public void setPlayer(Hero player)
        {
            this.player = player;
        }

        public void AddScene(Scene scene)
        {
            Scenes.Add(Scenes.Count, scene);
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
