using BinaryCartographicsEngine.BCEngine.Forms.Text;
using BinaryCartographicsEngine.BCEngine.Forms;
using BinaryCartographicsEngine.BCEngine.Cursor;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BinaryCartographicsEngine.BCEngine.Input;

namespace BinaryCartographicsEngine
{

    public class BCCore : Game
    {
        public float frameRate;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D Background;
        Texture2D Cursor;
        TextFont GameFont;
        Cursor2D RedPointer;
        System.Random random;
        TextBox TextBox;
        TextBox FpsCounter;
        TextBox CoordsChecker;
        Color clearcol = Color.Black;
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
            //IsMouseVisible = true;
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
            random = new System.Random();
            Background = Content.Load<Texture2D>("TestContent/Background");
            RedPointer = new Cursor2D(Content);
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //main panel
            panel = new Panel();
            panel.Position = new Vector2(0, 0);
            panel.Scale = new Vector2(0.5f, 2f);
            panel.Width = 400;
            panel.Height = 300;
            panel.Background = Background;
            panel.RotationDegrees = 45f;

            //child panel, pass in the main panel to access transform then add this to panel.controls to hook into update and draw methods
            childPanel = new Panel(panel);
            childPanel.tint = Color.Purple;
            childPanel.Position = new Vector2(20, 20);
            childPanel.Scale = new Vector2(0.2f, 0.2f);
            childPanel.Background = Background;
            panel.Controls.Add(childPanel);



            GameFont = new TextFont("BCGame/Fonts/taffer20x20", Content);

            //child text box, pass in the main panel to access transform then add this to panel.controls to hook into update and draw methods
            TextBox = new TextBox(panel, GameFont, 12, 1, GraphicsDevice);
            TextBox.Position = new Vector2(100, 100);
            TextBox.RotationDegrees = 0f;
            TextBox.Scale = new Vector2(2f, 1f);
            TextBox.Clear(' ', Color.Transparent, Color.Transparent);
            TextBox.Write("HELLO WORLD?", Color.Goldenrod, Color.Purple);
            panel.Controls.Add(TextBox);

            //Coords checker
            //For displaying coordinates
            CoordsChecker = new TextBox(GameFont, 30, 2, GraphicsDevice);
            CoordsChecker.Position = new Vector2(400, 0);
            CoordsChecker.Write("hello", Color.Green, Color.Red);
            //FPS text box, has no parent, will draw relative to the main window
            //FPScounter = new TextPanel(GameFont, Point.Zero , new Point(11, 1), GraphicsDevice);
            FpsCounter = new TextBox(GameFont, 20, 1, GraphicsDevice);
            // TODO: use this.Content to load your game content here


            //child button, pass in the main panel to access transform then add this to panel.controls to hook into update and draw methods
            button = new Button(panel, 50, 50);
            button.Position = new Vector2(200, 20);
            button.Scale = new Vector2(1f, 1f);
            button.Background = Background;

            button.MousePressHandler += SetBackgroundColor;
            button.MouseDownHandler += RandomisePanelColor;
            button.MouseHoverHandler += RamdomiseBGCol;
            panel.Controls.Add(button);
        }

        Color randCol()
        {
            int r = random.Next(0, 255);
            int g = random.Next(0, 255);
            int b = random.Next(0, 255);
            return new Color(r, g, b);
        }

        private void RamdomiseBGCol(object sender, System.EventArgs e)
        {
            clearcol = randCol();
        }

        private void RandomisePanelColor(object sender, System.EventArgs e)
        {
            childPanel.tint = randCol();
        }

        private void SetBackgroundColor(object sender, System.EventArgs e)
        {
            panel.tint = Color.Yellow;
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
            InputManager.Update();
            // TODO: Add your update logic here
            panel.Update();
            FpsCounter.Clear();
            FpsCounter.Write("FPS: " + frameRate.ToString(), Color.Green, Color.Black);

            Vector2 GlobalMousePos = InputManager.OldMouseState.Position.ToVector2();
            Vector2 LocalMousePos = button.InverseTransformVector(GlobalMousePos);

            CoordsChecker.Clear();
            CoordsChecker.Write("X:" + (int)GlobalMousePos.X + ", y:" + (int)GlobalMousePos.Y + 
                              "\nX:" + (int)LocalMousePos.X + ", y:" + (int)LocalMousePos.Y, 
                              Color.Red, Color.Green);

            RedPointer.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;

            GraphicsDevice.Clear(clearcol);
            ///MAIN CONTROL GRAPHICS TESTS
            spriteBatch.Begin(SpriteSortMode.Immediate,
      BlendState.AlphaBlend,
      SamplerState.PointClamp,
      null, null, null, null);

                panel.Draw(spriteBatch);

                CoordsChecker.Draw(spriteBatch);
                FpsCounter.Draw(spriteBatch);

            
            spriteBatch.End();



            ///BACKGROUND AND OTHER TESTS
            //GameTextPanel.Draw(spriteBatch);
            //FPScounter.Draw(spriteBatch);


            RedPointer.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
