using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Alpha
{

    #region ABSTRACT & TEMPLATE CLASS
    public class GameScreen
    {
        public bool IsActive = true;
        public bool IsPopup = false; 
        public Color BackgroundColor = Color.CornflowerBlue;

        public virtual void LoadAssets() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime) { }
        public virtual void UnloadAssets() { }
        protected virtual void AssetConfigurations() { }

    }

    /* DO NOT EDIT TEMPLATE CLASS!
     *  This is just to understand how the 
     *  class structure is layed out. 
     */
    #region Template
    public class TemplateScreen : GameScreen
    {

        /* 
         * Declare all Private Variables 
         * needed in specific ScreenClass
         */
        GameObject ship;        //Sprite is use for tests, we need Objects that inherit from Sprites
        float speed;
        public override void LoadAssets()
        {
            BackgroundColor = Color.DarkBlue; //Optional since most likely we will have Images

            /* 
             * ALL TEXTURES WILL BE INITILIAZED IN GAMESTATEMANAGER 1 TIME
             *  From then on, we can reuse it using the c_Sprite Dictionary:
             */
            ship = GameStateManager.c_OBJECT["GreenShip"]; // <----- Like that
            AssetConfigurations(); //Important - Look below for details of this function
            speed = 3.0f;
            base.LoadAssets();
        }

        /* 
         * Your Main Update Logic will be stored in here
         * NOTE: Complex updates that can be placed in a function
         *      should be placed in one to save clutter
         */
        public override void Update(GameTime gameTime)
        {
            
            Move(gameTime);     //<--- Basic function
            if (GameStateManager.m_INPUTMANAGER["Pause"].IsDown) //<---This is how we will be calling our Input (I know its long, 
                GameStateManager.ScreenSwitch(2);                //     I'll be think of a better way some other time).
            base.Update(gameTime);
        }

        /*
         * Honestly, UnloadAssets is somewhat obsolete with the 
         * advances of XNA garbage disposal process. But just for
         * practice, just set all class varables to null. Information
         * that needs to be carried over (such as level 1 to level 2 info
         * will be stored elsewhere so don't worry about that for now.
         */
        public override void UnloadAssets()
        {
            ship = null;
            base.UnloadAssets();
        }

        /*
         * Basic Draw Function
         * Gametime is here for FPS for the future when
         * we start using effects and such
         */
        public override void Draw(GameTime gameTime)
        {
            ship.Draw();
            base.Draw(gameTime);
        }

        /*
         * This is where basic asset adjustments will take place
         *  centering image, scaling, rotating...etc.
         *  NOTE: This is just initial set, up so don't use this
         *          as your update method
         */
        protected override void AssetConfigurations()
        {
            ship.Position = new Vector2(GameStateManager.centerX,
                GameStateManager.centerY);
            base.AssetConfigurations();
        }

        /* 
         * All custom made functions (Updates, Calculations...etc should go to the bottom
         *  Put your name on top of the function as well as a small description to help 
         *  your fellow programmers.
         */

        /* Michael Villar
         * Descritpion:
         * Used for movement of ship
         */
        private void Move(GameTime gameTime)
        {
            float x = ship.Position.X, y = ship.Position.Y;
            if(GameStateManager.m_INPUTMANAGER["W"].IsDown)
            {
               y -= (float)gameTime.ElapsedGameTime.TotalMilliseconds / speed;
            }
            if (GameStateManager.m_INPUTMANAGER["S"].IsDown)
            {
                y += (float)gameTime.ElapsedGameTime.TotalMilliseconds / speed;
            }
            if (GameStateManager.m_INPUTMANAGER["D"].IsDown)
            {
                x += (float)gameTime.ElapsedGameTime.TotalMilliseconds / speed;
            }
            if (GameStateManager.m_INPUTMANAGER["A"].IsDown)
            {
                x -= (float)gameTime.ElapsedGameTime.TotalMilliseconds / speed;
            }

            ship.Position = new Vector2(x, y);
        }
    }
#endregion
    #endregion


   /// <summary>
   /// This is the TestScreen for everyone to use 
   ///  Use Template Class as a reference if you don't understand something
   /// </summary>
    public class TestScreen : GameScreen
    {
        GameObject ship;
        Background background;

        public override void LoadAssets()
        {
            BackgroundColor = Color.Navy;
            ship = GameStateManager.c_OBJECT["RedShip"];
            background = GameStateManager.c_BGROUND["Menu"];
            AssetConfigurations();
            base.LoadAssets();
        }
        public override void Update(GameTime gameTime)
        {           
            base.Update(gameTime);
        }

        public override void UnloadAssets()
        {
            ship = null;
            base.UnloadAssets();
        }

        public override void Draw(GameTime gameTime)
        {
            background.Draw();
            ship.Draw();
            base.Draw(gameTime);
        }

        protected override void AssetConfigurations()
        {
            ship.Position = new Vector2(GameStateManager.centerX,
               GameStateManager.centerY);
            background.Position = new Vector2(GameStateManager.centerX,
                GameStateManager.centerY);
            base.AssetConfigurations();
        }
    }


    
}
