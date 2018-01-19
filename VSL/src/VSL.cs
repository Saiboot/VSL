using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace VSL
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class VSL : Game
    {
        public Vector2 ScreenCenter { get { return new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2); } }

        // Monogame utilities
        GraphicsDeviceManager g_Graphics;
        SpriteBatch g_SpriteBatch;

        Context.Entity e;

        // VSL utilities
        Controls.InputModule g_Input;

        Context.Globe Ball;

        public VSL()
        {
            g_Graphics = new GraphicsDeviceManager(this);
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
            base.Initialize();
            g_Input = new Controls.InputModule();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            g_SpriteBatch = new SpriteBatch(GraphicsDevice);
            Ball = new Context.Globe(Content, "ball", ScreenCenter, new Context.Handle(Content, "chain", ScreenCenter - new Vector2(10, 10), 250));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            g_Input.Pull_Events();
            if (g_Input.KeyState(Keys.Escape))
                Exit();

            for (int i = 0; i < Context.Entity.Collection.Count; i++)
                Context.Entity.Collection[i].Update(gameTime);

           
            Ball.m_Handle.setPos(g_Input.MousePos().ToVector2());

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            for (int i = 0; i < Context.Entity.Collection.Count; i++)
                Context.Entity.Collection[i].Draw(g_SpriteBatch);

            base.Draw(gameTime);
        }
    }
}
