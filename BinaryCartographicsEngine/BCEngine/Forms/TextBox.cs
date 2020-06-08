using BinaryCartographicsEngine.BCEngine.Forms.Text;
using BinaryCartographicsEngine.BCEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BinaryCartographicsEngine.BCEngine.Forms
{
    public class TextBox : TextControl
    {

        /// <param name="TextFont">The font image to use for rendering text to the text box</param>
        /// <param name="Width">Width in characters, this will scale depending on the font size</param>
        /// <param name="Height">Height in characters, this will scale depending on the font size</param>
        public TextBox(TextFont TextFont, int Width, int Height, GraphicsDevice Graphics) : base (TextFont, Width, Height, Graphics) //NOT IMPLEMENTED
        {
            buffer = new Buffer(Width, Height);
        }
        /// <param name="Parent">The parent control this object is attached to</param>
        /// <param name="Width">Width in characters, this will scale depending on the font size</param>
        /// <param name="Height">Height in characters, this will scale depending on the font size</param>
        public TextBox(Transform Parent, TextFont TextFont, int Width, int Height, GraphicsDevice Graphics) : base(Parent, TextFont, Width, Height, Graphics)
        {
            buffer = new Buffer(Width, Height);
        }
        public void SetCursorPosition(Point position)
        {
            buffer.SetCursorPosition(position);
        }
        public void SetCursorPosition(int X, int Y)
        {
            buffer.SetCursorPosition(X, Y);
        }
        public void Clear()
        {
            buffer.Clear();
        }
        public void Clear(char Char, Color ForeColor, Color BackColor)
        {
            buffer.Clear(Char, ForeColor, BackColor);
        }
        public void Write(char Char, Color ForeColor, Color BackColor)
        {
            buffer.Write(Char, ForeColor, BackColor);
        }
        public void Write(char Char, Color ForeColor, Color BackColor, Point Position)
        {
            buffer.Write(Char, ForeColor, BackColor, Position);
        }
        public void Write(char Char, Color ForeColor, Color BackColor, int X, int Y)
        {
            buffer.Write(Char, ForeColor, BackColor, X, Y);
        }
        public void Write(string String, Color ForeColor, Color BackColor)
        {
            buffer.Write(String, ForeColor, BackColor);
        }
        public void Write(string String, Color ForeColor, Color BackColor, Point Position)
        {
            buffer.Write(String, ForeColor, BackColor, Position);
        }
        public void Write(string String, Color ForeColor, Color BackColor, int X, int Y)
        {
            buffer.Write(String, ForeColor, BackColor, X, Y);
        }
    }
}
