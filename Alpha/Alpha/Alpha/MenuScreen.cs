using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alpha
{
    class MenuScreen : GameScreen
    {
    }

    class TitleScreen : MenuScreen
    {
        public override void LoadAssets()
        {
            base.LoadAssets();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
            if (GameStateManager.m_INPUTMANAGER["Left"].IsDown)
                  GameStateManager.JumpScreen(0);
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            GameStateManager.c_SPRITE["Menu"].Draw();
            base.Draw(gameTime);
        }
    }

    class PauseScreen : MenuScreen
    {
    }

    class OptionScreen : MenuScreen
    {

    }
}
