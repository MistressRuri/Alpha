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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
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
      
        //Custom Managers
        public static InputManager m_INPUTMANAGER;

        //Containers
        public static Dictionary<string, Sprite> c_SPRITE;
        public static Dictionary<string, SpriteFont> c_FONTS;
        public static LinkedList<GameScreen> c_STATELIST;

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
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            m_INPUTMANAGER = new InputManager();
            c_STATELIST = new LinkedList<GameScreen>();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
        // Create a new SpriteBatch, which can be used to draw textures.
            x_SPRITEBATCH = new SpriteBatch(GraphicsDevice);
            x_CONTENT = Content;

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            x_CONTENT.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (m_INPUTMANAGER["Quit"].IsDown)
                this.Exit();
            

            // TODO: Add your update logic here
            m_INPUTMANAGER.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void InitScreens()
        {
            
        }

       
    }
}
