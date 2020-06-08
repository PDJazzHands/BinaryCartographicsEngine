using BinaryCartographicsEngine.BCEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BinaryCartographicsEngine.BCEngine.Forms.Text
{
    public class TextControl : Control
    {
        public GraphicsDevice Graphics;

        public RenderTarget2D RenderTarget;

        public Buffer buffer;
        public TextFont TextFont;

        private static Point size;
        public Point Size
        {
            get { return size; }
            set
            {
                size = value;
                CreateScreenRect();
            }
        }
        /// <summary>
        /// CreateScreenRect and CreateRenderTarget are functions as they are very likely to be needed elsewhere
        /// </summary>
        public void CreateScreenRect()
        {
            ScreenRect = new Rectangle(
                0, 0,
                Size.X * TextFont.CharWidth,
                Size.Y * TextFont.CharHeight
            );
        }
        private static Rectangle screenRect;
        public Rectangle ScreenRect
        {
            get { return screenRect; }
            set
            {
                screenRect = value;
                CreateRenderTarget();
            }
        }
        public void CreateRenderTarget()
        {
            RenderTarget = new RenderTarget2D(Graphics, ScreenRect.Width, ScreenRect.Height);
        }
        /// <summary>
        /// TODO: add overloads.
        /// </summary>
        public TextControl(TextFont TextFont, int Width, int Height, GraphicsDevice Graphics)
        {
            this.Graphics = Graphics;
            buffer = new Buffer(Size.X, Size.Y);
            this.TextFont = TextFont;
            this.Size = new Point(Width, Height);
        }
        public TextControl(Transform Parent, TextFont TextFont, int Width, int Height, GraphicsDevice Graphics) : base(Parent)
        {
            this.Graphics = Graphics;
            buffer = new Buffer(Size.X, Size.Y);
            this.TextFont = TextFont;
            this.Size = new Point(Width, Height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            buffer.Draw(TextFont, spriteBatch, WorldTransform);
            base.Draw(spriteBatch);
        }
    }
}
