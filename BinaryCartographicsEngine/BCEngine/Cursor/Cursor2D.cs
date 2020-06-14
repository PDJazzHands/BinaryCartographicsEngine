using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BinaryCartographicsEngine.BCEngine.Cursor
{
    class Cursor2D
    {
        private Texture2D mouseTexture;
        private MouseState mouseState;
        public Cursor2D(ContentManager ContentManager) // default BCEngine cursor will be used
        {
            mouseTexture = ContentManager.Load<Texture2D>("BCEngine/Cursor/redCursor");
            mouseState = Mouse.GetState();
        }

        public void Update()
        {
            mouseState = Mouse.GetState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate,
BlendState.AlphaBlend,
SamplerState.PointClamp,
null, null, null, null);

            spriteBatch.Draw(mouseTexture, mouseState.Position.ToVector2(), Color.White);
            spriteBatch.End();
        }
    }
}
