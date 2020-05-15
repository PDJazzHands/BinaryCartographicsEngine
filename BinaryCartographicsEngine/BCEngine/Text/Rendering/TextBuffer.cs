using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryCartographicsEngine.BCEngine.Text.Rendering
{
    public class TextBuffer
    {
        private static Point ClearCharCoordinate = new Point(0, 2);
        private static TextChar ClearTile = new TextChar(Color.Transparent, Color.Transparent, ClearCharCoordinate);
        private static TextChar[,] CharArray;

        private static int bufferWidth;
        public int BufferWidth
        {
            get { return bufferWidth; }
        }

        private static int bufferHeight;
        public int BufferHeight
        {
            get { return bufferHeight; }
        }

        private static Point cursorPosition;
        public Point CursorPosition
        {
            get { return cursorPosition; }
            set
            {
                SetCursorPosition(value);
            }
        }

        public static void SetCursorPosition(Point position)
        {
            cursorPosition = new Point(
                MathHelper.Clamp(position.X, 0, bufferWidth),
                MathHelper.Clamp(position.Y, 0, bufferHeight)
                );
        }

        public static void SetCursorPosition(int X, int Y)
        {
            cursorPosition = new Point(
                MathHelper.Clamp(X, 0, bufferWidth),
                MathHelper.Clamp(Y, 0, bufferHeight)
                );
        }

        private static void IncrementCursorPosition()
        {
            cursorPosition.X++;
            if (cursorPosition.X >= bufferWidth)
            {
                cursorPosition.X = 0;
                if (cursorPosition.Y < bufferHeight)
                {
                    cursorPosition.Y++;
                }
            }
        }

        public TextBuffer(int Width, int Height)
        {
            bufferWidth = Width;
            bufferHeight = Height;
            CharArray = new TextChar[Width, Height];
            Clear();
        }

        public static void Clear()
        {
            for (int y = 0; y < CharArray.GetLength(1); y++)
            {
                for (int x = 0; x < CharArray.GetLength(0); x++)
                {
                    CharArray[x, y] = ClearTile;
                }
            }
            SetCursorPosition(Point.Zero);
        }
        public static void Clear(char Char, Color ForeColor, Color BackColor)
        {
            for (int y = 0; y < CharArray.GetLength(1); y++)
            {
                for (int x = 0; x < CharArray.GetLength(0); x++)
                {
                    CharArray[x, y] = new TextChar(ForeColor, BackColor, Char); ;
                }
            }
            SetCursorPosition(Point.Zero);
        }

        public static void Write(char Char, Color ForeColor, Color BackColor)
        {
            CharArray[cursorPosition.X, cursorPosition.Y] = new TextChar(ForeColor, BackColor, Char);
            IncrementCursorPosition();
        }
        public static void Write(char Char, Color ForeColor, Color BackColor, Point position)
        {
            SetCursorPosition(position);
            CharArray[cursorPosition.X, cursorPosition.Y] = new TextChar(ForeColor, BackColor, Char);
            IncrementCursorPosition();
        }
        public static void Write(char Char, Color ForeColor, Color BackColor, int X, int Y)
        {
            SetCursorPosition(X, Y);
            CharArray[cursorPosition.X, cursorPosition.Y] = new TextChar(ForeColor, BackColor, Char);
            IncrementCursorPosition();
        }

        public static void Write(string String, Color ForeColor, Color BackColor)
        {
            int position = cursorPosition.X;
            foreach (char c in String)
            {
                if (c == '\n')
                {
                    SetCursorPosition(position, cursorPosition.Y + 1);
                }
                else
                {
                    CharArray[cursorPosition.X, cursorPosition.Y] = new TextChar(ForeColor, BackColor, c);
                    IncrementCursorPosition();
                }
            }
        }
        public static void Write(string String, Color ForeColor, Color BackColor, Point position)
        {
            SetCursorPosition(position);
            foreach (char c in String)
            {
                if (c == '\n')
                {
                    SetCursorPosition(position.X, cursorPosition.Y + 1);
                }
                else
                {
                    CharArray[cursorPosition.X, cursorPosition.Y] = new TextChar(ForeColor, BackColor, c);
                    IncrementCursorPosition();
                }
            }
        }
        public static void Write(string String, Color ForeColor, Color BackColor, int X, int Y)
        {
            SetCursorPosition(X, Y);
            foreach (char c in String)
            {
                if (c == '\n')
                {
                    SetCursorPosition(X, cursorPosition.Y + 1);
                }
                else
                {
                    CharArray[cursorPosition.X, cursorPosition.Y] = new TextChar(ForeColor, BackColor, c);
                    IncrementCursorPosition();
                }
            }
        }


        public static void Draw(TextFont TextFont, SpriteBatch spriteBatch, Point Location)
        {
            for (int y = 0; y < CharArray.GetLength(1); y++)
            {
                for (int x = 0; x < CharArray.GetLength(0); x++)
                {
                    Point SamplePos = new Point(CharArray[x, y].SamplePosition.X * TextFont.CharSize.X, CharArray[x, y].SamplePosition.Y * TextFont.CharSize.Y);
                    Rectangle SourceRect = new Rectangle(SamplePos, TextFont.CharSize);
                    Vector2 Position = new Vector2(x * TextFont.CharSize.X + Location.X, y * TextFont.CharSize.Y + Location.Y);


                    TextFont.FontEffect.Parameters["ForeColor"].SetValue(CharArray[x, y].ForeColor.ToVector4());
                    TextFont.FontEffect.Parameters["BackColor"].SetValue(CharArray[x, y].BackColor.ToVector4());
                    TextFont.FontEffect.CurrentTechnique.Passes[0].Apply();

                    spriteBatch.Draw(TextFont.FontSheet, Position, SourceRect, Color.White);
                }
            }
        }
    }
}
