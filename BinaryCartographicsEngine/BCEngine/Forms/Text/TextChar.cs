using Microsoft.Xna.Framework;

namespace BinaryCartographicsEngine.BCEngine.Forms.Text
{

    public struct TextChar
    {
        public readonly Color ForeColor;
        public readonly Color BackColor;
        public readonly Point SamplePosition;

        public TextChar(Color ForeColor, Color BackColor, Point SamplePosition)
        {
            this.ForeColor = ForeColor;
            this.BackColor = BackColor;
            this.SamplePosition = SamplePosition;
        }

        public TextChar(Color ForeColor, Color BackColor, char Char)
        {
            this.ForeColor = ForeColor;
            this.BackColor = BackColor;
            this.SamplePosition = TextConvertor.GetCharCoordinate(Char);
        }
    }
}
