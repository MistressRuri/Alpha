using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Alpha
{
    
    public class GameStateManager : Game
    {

        /* Declaration - Key
         * c = Container
         * m = Manager
         * x = XNA
         * v = Variable      */
        //XNA
        public static GraphicsDeviceManager x_GRAPHIC;
        public static SpriteBatch x_SPRITEBATCH;
        public static Effect x_EFFECTS;
        public static ContentManager x_CONTENT;
        public static Viewport x_VIEWPORT;
      
        //Custom Managers
        public static InputManager m_INPUTMANAGER;

        //Containers
        public static Dictionary<string, Sprite> c_SPRITE;
        public static Dictionary<string, SpriteFont> c_FONTS;
        public static List<GameScreen> c_STATELIST;

        //GameStateManager Variables
        static GameScreen v_currentScreen;
        static bool FullScreen = false;

        //Globals
        public static float centerX, centerY;
        

        public static void Main()
        {
            using (GameStateManager MANAGER = new GameStateManager())
            {
                MANAGER.Run();
            }
        }
        
        public GameStateManager()
        {
            x_GRAPHIC = new GraphicsDeviceManager(this);
            x_GRAPHIC.PreferredBackBufferWidth = 800;
            x_GRAPHIC.PreferredBackBufferHeight = 600;
            x_GRAPHIC.IsFullScreen = false;
            x_GRAPHIC.ApplyChanges();
            Content.RootDirectory = "Content";
        }

      
        protected override void Initialize()
        {
            m_INPUTMANAGER = new InputManager();
            c_STATELIST = new List<GameScreen>();
            InitScreens();
            v_currentScreen = c_STATELIST[0];
            base.Initialize();
        }

        protected override void LoadContent()
        {           
            x_SPRITEBATCH = new SpriteBatch(x_GRAPHIC.GraphicsDevice);
            x_VIEWPORT = x_GRAPHIC.GraphicsDevice.Viewport;
            x_VIEWPORT.Height = 600;
            x_VIEWPORT.Width = 800;
            centerX = x_VIEWPORT.Width / 2;
            centerY = x_VIEWPORT.Height / 2;
            x_CONTENT = Content;
            c_SPRITE = new Dictionary<string, Sprite>();
            LoadAssets();
            v_currentScreen.LoadAssets();

        }

        protected override void UnloadContent()
        {
            x_CONTENT.Unload();
        }

        
        protected override void Update(GameTime gameTime)
        {
           
            if (m_INPUTMANAGER["Escape"].IsDown)
                this.Exit();
           
            v_currentScreen.Update(gameTime);
            m_INPUTMANAGER.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            x_GRAPHIC.GraphicsDevice.Viewport = x_VIEWPORT;
            x_GRAPHIC.GraphicsDevice.Clear(v_currentScreen.BackgroundColor);
            
            x_SPRITEBATCH.Begin();
            v_currentScreen.Draw(gameTime);
            base.Draw(gameTime);
            x_SPRITEBATCH.End();
        }

        private void InitScreens()      // Initializes SplashScreen, TitleScreen, PauseScreen
        {
           // c_STATELIST.Add(new SplashScreen());
            c_STATELIST.Add(new TitleScreen());
            c_STATELIST.Add(new TemplateScreen());
            c_STATELIST.Add(new TestScreen());
        }

        private void LoadAssets() 
        {
            c_SPRITE.Add("LeagueLogo", new Sprite("Test/The League Logo"));
            c_SPRITE.Add("Menu", new Sprite("Test/GeoMenu"));
            c_SPRITE.Add("Menu2", new Sprite("Test/Menu"));
            c_SPRITE.Add("GreenShip", new Sprite("Test/ship1"));
            c_SPRITE.Add("RedShip", new Sprite("Test/ship2"));
        }

        public static void FullScreenToggle()
        {
            if (m_INPUTMANAGER["Full"].IsDown && !FullScreen)
                FullScreen = true;
            if (!m_INPUTMANAGER["Full"].IsDown && FullScreen)
            {
                x_GRAPHIC.ToggleFullScreen();
                FullScreen = false;
            }
        }

        public static void ScreenSwitch(int screen)
        {
            v_currentScreen.UnloadAssets();
            v_currentScreen = c_STATELIST[screen];
            v_currentScreen.LoadAssets();
        }

        public static void SplashDelete()
        {
            c_STATELIST[0].UnloadAssets();
            c_STATELIST.RemoveAt(0);
            v_currentScreen = c_STATELIST[0];
            v_currentScreen.LoadAssets();
        }

       
        

       
    }
}
