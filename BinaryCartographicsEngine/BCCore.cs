using BinaryCartographicsEngine.BCEngine.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BinaryCartographicsEngine
{

    public class BCCore : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D Background;
        TextFont GameFont;
        TextPanel GameTextPanel;
        TextFont GameFont2;
        TextPanel GameTextPanel2;

        public BCCore()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
            base.Initialize();
        }


        protected override void LoadContent()
        {
            /* Initialize the TextConvertor, This must not be removed unless 
             * another method of managing and rendering text is used */
            TextConvertor.Initialize();

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            Background = Content.Load<Texture2D>("TestContent/Background");
            GameFont = new TextFont("BCGame/Fonts/teeto18", Content);
            GameTextPanel = new TextPanel(GameFont, new Point(32, 32), new Point(16, 16), GraphicsDevice);
            GameTextPanel.Clear('♥', new Color(1f, 0f, 0f, 0.5f), new Color(1f, 1f, 1f, 0.25f));
            GameTextPanel.SetCursorPosition(1, 1);
            GameTextPanel.Write("Spank\nMachine", Color.Goldenrod, Color.Black);
            GameTextPanel.Write("wank.", Color.Honeydew, Color.Purple, 3, 5);
            GameTextPanel.Write("WORD-WRAP-TESTING-WORD-WRAP-TESTING", Color.SaddleBrown, Color.Pink, 5, 7);
            GameFont2 = new TextFont("BCGame/Fonts/taffer20x20", Content);
            GameTextPanel2 = new TextPanel(GameFont2, new Point(56, 60), new Point(16, 16), GraphicsDevice);
            GameTextPanel2.Clear('♥', new Color(1f, 0f, 0f, 0.5f), new Color(1f, 1f, 1f, 0.25f));
            GameTextPanel2.SetCursorPosition(1, 1);
            GameTextPanel2.Write("Spank\nMachine", Color.Goldenrod, Color.Black);
            GameTextPanel2.Write("wank.", Color.Honeydew, Color.Purple, 3, 5);
            GameTextPanel2.Write("WORD-WRAP-TESTING-WORD-WRAP-TESTING", Color.SaddleBrown, Color.Pink, 5, 7);
            // TODO: use this.Content to load your game content here


        }

        protected override void UnloadContent()
        {
            // It is generally good practise to Dispose() then set to null.
            Background.Dispose();
            Background = null;
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            GameTextPanel2.Draw(spriteBatch);
            GameTextPanel.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
