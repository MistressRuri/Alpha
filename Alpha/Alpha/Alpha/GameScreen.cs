using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;


namespace Alpha
{
    public class GameScreen
    {
        public bool IsActive = true;
        public bool IsPopup = false; 
        public Color BackgroundColor = Color.CornflowerBlue;

        public virtual void LoadAssets() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime) { }
        public virtual void UnloadAssets() { }

    }

    public class TestScreen:GameScreen
    {
        public override void LoadAssets()
        {
            GameStateManager.c_SPRITE.Add("Ship-1", new Sprite("test/ship1"));
            base.LoadAssets();
        }
        public override void Draw(GameTime gameTime)
        {
            GameStateManager.c_SPRITE["Ship-1"].Draw();
            base.Draw(gameTime);
        }
    }

    
}
