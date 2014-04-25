using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Alpha
{
    class TitleScreen : GameScreen
    {
        Background background;
        public override void LoadAssets()
        {
            background = GameStateManager.c_BGROUND["Menu"];
            AssetConfigurations();
            base.LoadAssets();
        }
        public override void UnloadAssets()
        {
            background = null;
            base.UnloadAssets();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
            if (GameStateManager.m_INPUTMANAGER["Enter"].IsDown)
                  GameStateManager.ScreenSwitch(1);
            GameStateManager.FullScreenToggle();
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            background.Draw();
            base.Draw(gameTime);
        }

        protected override void AssetConfigurations()
        {
            background.Position =
                new Vector2(GameStateManager.centerX, GameStateManager.centerY);
            background.Scale = .95f;
            base.AssetConfigurations();
        }
    }

    class PauseScreen : GameScreen
    {
    }

    class OptionScreen : GameScreen
    {

    }
}
