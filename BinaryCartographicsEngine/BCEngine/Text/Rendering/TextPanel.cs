using BinaryCartographicsEngine.BCEngine.Text.Conversion;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BinaryCartographicsEngine.BCEngine.Text.Rendering
{
    public class TextPanel //: TextRendererBase
    {
        GraphicsDevice Graphics;

        public RenderTarget2D RenderTarget;

        public TextBuffer TextBuffer;
        public TextFont TextFont;

        private static Point position;
        public Point Position
        {
            get { return position; }
            set
            {
                position = value;
                CreateScreenRect();
            }
        }
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
        /// <summary>
        /// CreateScreenRect and CreateRenderTarget are functions as they are very likely to be needed elsewhere
        /// </summary>
        public void CreateScreenRect()
        {
            ScreenRect = new Rectangle(
                Position.X,
                Position.Y, 
                Size.X * TextFont.CharWidth, 
                Size.Y * TextFont.CharHeight
            );
        }
        public void CreateRenderTarget()
        {
            RenderTarget = new RenderTarget2D(Graphics, ScreenRect.Width, ScreenRect.Height);
        }

        public TextPanel(TextFont TextFont, Point Position, Point Size, GraphicsDevice Graphics)
        {
            this.Graphics = Graphics;
            TextBuffer = new TextBuffer(Size.X, Size.Y);
            this.TextFont = TextFont;
            this.Size = Size;
            this.Position = Position;
        }

        #region TextBuffer wrapper functions
        public void SetCursorPosition(Point position)
        {
            TextBuffer.SetCursorPosition(position);
        }
        public void SetCursorPosition(int X, int Y)
        {
            TextBuffer.SetCursorPosition(X, Y);
        }
        public void Clear()
        {
            TextBuffer.Clear();
        }
        public void Clear(char Char, Color ForeColor, Color BackColor)
        {
            TextBuffer.Clear(Char, ForeColor, BackColor);
        }
        public void Write(char Char, Color ForeColor, Color BackColor)
        {
            TextBuffer.Write(Char, ForeColor, BackColor);
        }
        public void Write(char Char, Color ForeColor, Color BackColor, Point Position)
        {
            TextBuffer.Write(Char, ForeColor, BackColor, Position);
        }
        public void Write(char Char, Color ForeColor, Color BackColor, int X, int Y)
        {
            TextBuffer.Write(Char, ForeColor, BackColor, X, Y);
        }
        public void Write(string String, Color ForeColor, Color BackColor)
        {
            TextBuffer.Write(String, ForeColor, BackColor);
        }
        public void Write(string String, Color ForeColor, Color BackColor, Point Position)
        {
            TextBuffer.Write(String, ForeColor, BackColor, Position);
        }
        public void Write(string String, Color ForeColor, Color BackColor, int X, int Y)
        {
            TextBuffer.Write(String, ForeColor, BackColor, X, Y);
        }
        public void Draw(SpriteBatch SpriteBatch)
        {
            TextBuffer.Draw(TextFont, SpriteBatch, Position);
        }
        #endregion
    }
}
