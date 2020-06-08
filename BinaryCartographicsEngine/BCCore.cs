using BinaryCartographicsEngine.BCEngine.Forms.Text;
using BinaryCartographicsEngine.BCEngine.Forms;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BinaryCartographicsEngine
{

    public class BCCore : Game
    {
        public float frameRate;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D Background;
        TextFont GameFont;

        TextBox TextBox;
        TextBox FpsCounter;

        Panel panel;
        Panel childPanel;
        Button button;

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

            Background = Content.Load<Texture2D>("TestContent/Background");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //main panel
            panel = new Panel();
            panel.Position = new Vector2(200, -100);
            panel.Scale = new Vector2(0.9f, 1.2f);
            panel.Background = Background;
            panel.RotationDegrees = 45f;

            //child panel, pass in the main panel to access transform then add this to panel.controls to hook into update and draw methods
            childPanel = new Panel(panel);
            childPanel.tint = Color.Purple;
            childPanel.Position = new Vector2(20, 20);
            childPanel.Scale = new Vector2(0.2f, 0.2f);
            childPanel.Background = Background;
            panel.Controls.Add(childPanel);

            //child button, pass in the main panel to access transform then add this to panel.controls to hook into update and draw methods
            button = new Button(panel);
            button.Position = new Vector2(200, 20);
            button.Scale = new Vector2(0.5f, 0.5f);
            button.Background = Background;
            panel.Controls.Add(button);

            GameFont = new TextFont("BCGame/Fonts/taffer20x20", Content);

            //child text box, pass in the main panel to access transform then add this to panel.controls to hook into update and draw methods
            TextBox = new TextBox(panel, GameFont, 12, 1, GraphicsDevice);
            TextBox.Position = new Vector2(100, 100);
            TextBox.RotationDegrees = 0f;
            TextBox.Scale = new Vector2(2f, 1f);
            TextBox.Clear(' ', Color.Transparent, Color.Transparent);
            TextBox.Write("HELLO WORLD?", Color.Goldenrod, Color.Purple);
            panel.Controls.Add(TextBox);

            //FPS text box, has no parent, will draw relative to the main window
            //FPScounter = new TextPanel(GameFont, Point.Zero , new Point(11, 1), GraphicsDevice);
            FpsCounter = new TextBox(GameFont, 20, 1, GraphicsDevice);
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
            panel.Update();
            FpsCounter.Clear();
            FpsCounter.Write("FPS: " + frameRate.ToString(), Color.Green, Color.Black);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;

            GraphicsDevice.Clear(Color.Black);
            ///MAIN CONTROL GRAPHICS TESTS
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
            panel.Draw(spriteBatch);
            TextBox.Draw(spriteBatch);
            FpsCounter.Draw(spriteBatch);
            spriteBatch.End();

            ///BACKGROUND AND OTHER TESTS
            //GameTextPanel.Draw(spriteBatch);
            //FPScounter.Draw(spriteBatch);


            base.Draw(gameTime);
        }
    }
}
