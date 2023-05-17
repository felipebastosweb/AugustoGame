using System.Collections.Generic;

using Engine2D.Entities;

namespace Engine2D.SpriteSheets
{
    public class SpriteSheet : ISpriteSheet
    {
        public Dictionary<string, Sprite> Sprites;
        public SpriteSheet()
        {
            Sprites = new Dictionary<string, Sprite>();
        }

        public void Add(string name, Sprite sprite)
        {
            Sprites.Add(name, sprite);
        }
    }
}
