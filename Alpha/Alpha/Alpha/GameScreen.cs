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

    #region TestScreens
    public class TestScreen : GameScreen
    {
        
        public override void LoadAssets()
        {
            BackgroundColor = Color.Beige;
            GameStateManager.c_SPRITE.Add("Ship1", new Sprite("test/ship1"));
            base.LoadAssets();
        }
        public override void Update(GameTime gameTime)
        {
            if (GameStateManager.m_INPUTMANAGER["Left"].IsDown)
                GameStateManager.JumpScreen(1);
            base.Update(gameTime);
        }
        public override void UnloadAssets()
        {
            GameStateManager.c_SPRITE.Remove("Ship1");
            base.UnloadAssets();
        }
        public override void Draw(GameTime gameTime)
        {            
            GameStateManager.c_SPRITE["Ship1"].Draw();
            base.Draw(gameTime);
        }
    }

    public class TestScreen1 : GameScreen
    {

        public override void LoadAssets()
        {
            BackgroundColor = Color.BlueViolet;
            GameStateManager.c_SPRITE.Add("Ship2", new Sprite("test/ship2"));
            base.LoadAssets();
        }
        public override void Update(GameTime gameTime)
        {
            if (GameStateManager.m_INPUTMANAGER["Left"].IsDown)
                GameStateManager.JumpScreen(2);
            base.Update(gameTime);
        }
        public override void UnloadAssets()
        {
            GameStateManager.c_SPRITE.Remove("Ship2");
            base.UnloadAssets();
        }
        public override void Draw(GameTime gameTime)
        {
            GameStateManager.c_SPRITE["Ship2"].Draw();
            base.Draw(gameTime);
        }
    }
#endregion

    
}
