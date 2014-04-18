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
        public static ContentManager x_CONTENT;
        public static Viewport x_VIEWPORT;
      
        //Custom Managers
        public static InputManager m_INPUTMANAGER;

        //Containers
        public static Dictionary<string, Sprite> c_SPRITE;
        public static Dictionary<string, SpriteFont> c_FONTS;
        public static List<GameScreen> c_STATELIST;

        //Variables
        static GameScreen v_currentScreen;
        

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
            x_VIEWPORT = new Viewport();
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
            x_SPRITEBATCH = new SpriteBatch(GraphicsDevice);
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
           
            if (m_INPUTMANAGER["Quit"].IsDown)
                this.Exit();
            v_currentScreen.Update(gameTime);
            m_INPUTMANAGER.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(v_currentScreen.BackgroundColor);
            x_SPRITEBATCH.Begin();
            v_currentScreen.Draw(gameTime);
            base.Draw(gameTime);
            x_SPRITEBATCH.End();
        }

        private void InitScreens()      // Initializes SplashScreen, TitleScreen, PauseScreen
        {
            c_STATELIST.Add(new TestScreen());
            c_STATELIST.Add(new TestScreen1());
            //c_STATELIST.Add(new SplashScreen());
            c_STATELIST.Add(new TitleScreen());
            //c_STATELIST.Add(new PauseScreen());
        }

        public static void JumpScreen(int screen)
        {
            v_currentScreen.UnloadAssets();
            v_currentScreen = c_STATELIST[screen];
            v_currentScreen.LoadAssets();
        }

        private void LoadAssets() // Global Assets
        {
            c_SPRITE.Add("Menu", new Sprite("Test/Menu"));
            c_SPRITE.Add("boloLadder", new Sprite("Test/boloLadder"));
            c_SPRITE.Add("ship1", new Sprite("Test/ship1"));
            c_SPRITE.Add("ship2", new Sprite("Test/ship2"));
        }

       
    }
}
