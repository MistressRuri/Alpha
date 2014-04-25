using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Alpha
{
    public class Background
    {
        protected Sprite sprite;
        protected GameScreen screen;

        public Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }
        public float Rotation { get { return sprite.rotation; } set { sprite.rotation = value; } }
        public float Scale { get { return sprite.scale; } set { sprite.scale = value; } }
        public GameScreen Screen { get { return screen; } }

        public Background(string fileName)
        {
            sprite = new Sprite(fileName);
        }

        public void Update(GameTime gameTime) { }
        public void Draw()
        {
            sprite.Draw();
        }
    }
}
