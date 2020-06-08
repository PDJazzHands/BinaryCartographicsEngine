
using BinaryCartographicsEngine.BCEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BinaryCartographicsEngine.BCEngine.Forms.Text
{
    public class Buffer
    {
        private static Point ClearCharCoordinate = new Point(0, 2);
        private static TextChar ClearTile = new TextChar(Color.Transparent, Color.Transparent, ClearCharCoordinate);
        private TextChar[,] CharArray;

        private static int bufferWidth;
        public int BufferWidth
        {
            get { return bufferWidth; }
        }

        private static int bufferHeight;
        public static int BufferHeight
        {
            get { return bufferHeight; }
        }

        private Point cursorPosition;
        public Point CursorPosition
        {
            get { return cursorPosition; }
            set
            {
                SetCursorPosition(value);
            }
        }

        public void SetCursorPosition(Point position)
        {
            cursorPosition = new Point(
                MathHelper.Clamp(position.X, 0, bufferWidth),
                MathHelper.Clamp(position.Y, 0, bufferHeight)
                );
        }

        public void SetCursorPosition(int X, int Y)
        {
            cursorPosition = new Point(
                MathHelper.Clamp(X, 0, bufferWidth),
                MathHelper.Clamp(Y, 0, bufferHeight)
                );
        }

        private void IncrementCursorPosition()
        {
            int xPos = cursorPosition.X + 1;
            int yPos = cursorPosition.Y;
            if (xPos >= bufferWidth)
            {
                xPos = 0;
                if (cursorPosition.Y < bufferHeight)
                {
                    yPos++;
                }
            }
            SetCursorPosition(xPos, yPos);
        }

        public Buffer(int Width, int Height)
        {
            bufferWidth = Width;
            bufferHeight = Height;
            CharArray = new TextChar[Width, Height];
            Clear();
        }

        public void Clear()
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
        public void Clear(char Char, Color ForeColor, Color BackColor)
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

        public void Write(char Char, Color ForeColor, Color BackColor)
        {
            CharArray[cursorPosition.X, cursorPosition.Y] = new TextChar(ForeColor, BackColor, Char);
            IncrementCursorPosition();
        }
        public void Write(char Char, Color ForeColor, Color BackColor, Point position)
        {
            SetCursorPosition(position);
            CharArray[cursorPosition.X, cursorPosition.Y] = new TextChar(ForeColor, BackColor, Char);
            IncrementCursorPosition();
        }
        public void Write(char Char, Color ForeColor, Color BackColor, int X, int Y)
        {
            SetCursorPosition(X, Y);
            CharArray[cursorPosition.X, cursorPosition.Y] = new TextChar(ForeColor, BackColor, Char);
            IncrementCursorPosition();
        }

        public void Write(string String, Color ForeColor, Color BackColor)
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
        public void Write(string String, Color ForeColor, Color BackColor, Point position)
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
        public void Write(string String, Color ForeColor, Color BackColor, int X, int Y)
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

        public Vector2 RotateAboutOrigin(Vector2 point, Vector2 origin, float rotation)
        {
            return Vector2.Transform(point - origin, Matrix.CreateRotationZ(rotation)) + origin;
        }

        public void Draw(TextFont TextFont, SpriteBatch spriteBatch, Transform worldTransform)
        {
            for (int y = 0; y < CharArray.GetLength(1); y++)
            {
                for (int x = 0; x < CharArray.GetLength(0); x++)
                {
                    Point SamplePos = new Point(CharArray[x, y].SamplePosition.X * TextFont.CharSize.X, CharArray[x, y].SamplePosition.Y * TextFont.CharSize.Y);
                    Rectangle SourceRect = new Rectangle(SamplePos, TextFont.CharSize);
                    //location is the input draw location, apply this to the draw method of the render target, not here
                    Vector2 Position = new Vector2(x * TextFont.CharSize.X, y * TextFont.CharSize.Y);
                    Position *= worldTransform.Scale;
                    Position = RotateAboutOrigin(Position, Vector2.Zero, worldTransform.Rotation);

                    TextFont.FontEffect.Parameters["ForeColor"].SetValue(CharArray[x, y].ForeColor.ToVector4());
                    TextFont.FontEffect.Parameters["BackColor"].SetValue(CharArray[x, y].BackColor.ToVector4());
                    TextFont.FontEffect.CurrentTechnique.Passes[0].Apply();
                    //spriteBatch.Draw(TextFont.FontSheet, Position, SourceRect, Color.White);
                    
                    spriteBatch.Draw(TextFont.FontSheet, worldTransform.WorldPosition + Position, SourceRect, Color.White, worldTransform.WorldRotation, Vector2.Zero, worldTransform.WorldScale, SpriteEffects.None, 0f);
                }
            }
        }
    }
}
