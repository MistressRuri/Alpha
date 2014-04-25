using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Alpha
{
    class SplashScreen : GameScreen
    {
        Background background;
        public override void LoadAssets()
        {
            BackgroundColor = Color.Black;
            background = GameStateManager.c_BGROUND["LeagueLogo"];
            AssetConfigurations();
            base.LoadAssets();
        }

        public override void UnloadAssets()
        {
            background = null;
            base.UnloadAssets();
        }

        public override void Update(GameTime gameTime)
        {

            if (gameTime.TotalGameTime.TotalSeconds >= 3.5f)
                GameStateManager.SplashDelete();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {                
            background.Draw();
            base.Draw(gameTime);
        }

        protected override void AssetConfigurations()
        {
            background.Position =
                new Vector2(GameStateManager.centerX, GameStateManager.centerY);
            background.Scale = 0.6f;
            base.AssetConfigurations();
        }
    }
}
