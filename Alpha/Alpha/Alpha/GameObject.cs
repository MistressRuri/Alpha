using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Alpha
{
    public class GameObject
    {

        protected Sprite sprite;
        protected GameScreen screen;       
        protected Rectangle hitbox;
    
        public Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }
        public float Rotation { get { return sprite.rotation; } set { sprite.rotation = value; } }
        public GameScreen Screen { get { return screen; } }
        public Rectangle Hitbox { get { return hitbox; } }
        
        public GameObject(string fileName)
        {
            sprite = new Sprite(fileName);
            hitbox = sprite.sourceRect;
        }

        public virtual void Update(GameTime time)
        {

        }

        public void Draw()
        {
            sprite.Draw();
        }
    }
}