using BinaryCartographicsEngine.Engine.Utilities.Dictionaries;
using Microsoft.Xna.Framework;

namespace BinaryCartographicsEngine.BCEngine.Forms.Text
{
    public static class TextConvertor
    {
        private static bool isInitialized = false;
        private static char[] CodePageData =
        {
        (char)0,'☺','☻','♥','♦','♣','♠','•','◘','○','◙','♂','♀','♪','♫','☼',
            '►','◄','↕','‼','¶','§','▬','↨','↑','↓','→','←','∟','↔','▲','▼',
            ' ','!','\"','#','$','%','&','\'','(',')','*','+',',','-','.','/',
            '0','1','2','3','4','5','6','7','8','9',':',';','<','=','>','?',
            '@','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O',
            'P','Q','R','S','T','U','V','W','X','Y','Z','[','\\',']','^','_',
            '`','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o',
            'p','q','r','s','t','u','v','w','x','y','z','{','∶','}','~','⌂',
            'Ç','ü','é','â','ä','à','å','ç','ê','ë','è','ï','î','ì','Ä','Å',
            'É','æ','Æ','ô','ö','ò','û','ù','ÿ','Ö','Ü','¢','£','￥','₧','ƒ',
            'á','í','ó','ú','ñ','Ñ','ª','º','¿','⌐','¬','½','¼','¡','«','»',
            '░','▒','▓','│','┤','╡','╢','╖','╕','╣','║','╗','╝','╜','╛','┐',
            '└','┴','┬','├','─','┼','╞','╟','╚','╔','╩','╦','╠','═','╬','╧',
            '╨','╤','╥','╙','╘','╒','╓','╫','╪','┘','┌','█','▄','▌','▐','▀',
            'α','ß','Γ','π','Σ','σ','µ','τ','Φ','Θ','Ω','δ','∞','φ','ε','∩',
            '≡','±','≥','≤','⌠','⌡','÷','≈','°','∙','·','√','ⁿ','²','■','\n'
        };

        private static readonly TwoWayDictionary<char, int> CharDictionary = new TwoWayDictionary<char, int>();
        /// <summary>
        /// Initialize creates a dictionary that maps char values to int values for 
        /// the two way dictionary to function, this must be called on LoadContent in 
        /// BCCore, or else it will crash
        /// </summary>
        public static void Initialize()
        {
            if (!isInitialized)
            {
                for (int i = 0; i < 256; i++)
                {
                    CharDictionary.Add(CodePageData[i], i);
                }
                isInitialized = true;
            }
        }

        public static int GetCharIndex(char inChar)
        {
            return CharDictionary[inChar];
        }

        public static char GetIndexedChar(int InIndex)
        {
            return CharDictionary[InIndex];
        }

        public static Point GetCharCoordinate(char inChar)
        {
            int charVal = CharDictionary[inChar];
            return new Point(charVal % 16, charVal / 16);
        }
    }
}
