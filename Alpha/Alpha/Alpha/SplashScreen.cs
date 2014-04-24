using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Alpha
{
    class SplashScreen : GameScreen
    {
        Sprite background;
        public override void LoadAssets()
        {
            BackgroundColor = Color.Black;
            background = GameStateManager.c_SPRITE["LeagueLogo"];
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
            background.position =
                new Vector2(GameStateManager.centerX, GameStateManager.centerY);
            background.scale = 0.6f;
            base.AssetConfigurations();
        }
    }
}
