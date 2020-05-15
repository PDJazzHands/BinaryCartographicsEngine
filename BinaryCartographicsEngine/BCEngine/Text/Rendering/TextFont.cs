using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BinaryCartographicsEngine.BCEngine.Text.Rendering
{
    public class TextFont
    {
        public Effect FontEffect;
        public Texture2D FontSheet;
        public string Name;

        public int CharWidth;
        public int CharHeight;
        public Point CharSize;

        public TextFont(string FontSheetName, ContentManager ContentManager)  // GraphicsDevice Graphics, SpriteBatch SpriteBatch, ContentManager ContentManager)
        {
            FontEffect = ContentManager.Load<Effect>("BCEngine/Text/FontEffect");
            FontSheet = ContentManager.Load<Texture2D>(FontSheetName);
            this.Name = FontSheetName;

            // using /16 since the font sheets are 16 chars wide and tall, this should be updated if any other formats are used
            CharWidth = (FontSheet.Width / 16);
            CharHeight = (FontSheet.Height / 16);
            CharSize = new Point(CharWidth, CharHeight);
        }
    }
}
