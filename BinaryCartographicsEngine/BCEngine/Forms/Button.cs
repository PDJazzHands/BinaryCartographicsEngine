using BinaryCartographicsEngine.BCEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BinaryCartographicsEngine.BCEngine.Forms
{
    class Button : Control
    {
        public Button() { }
        public Button(Transform Parent) : base(Parent) { }

        public Texture2D Background;
        Color test;

        public override void Update()
        {

            Rectangle worldRect = new Rectangle(this.Position.ToPoint(), (Point)(Background.Bounds.Size * this.Scale.ToPoint()));
            Point mousePos;
            //MouseState m = new MouseState();

            //test = Color.Red;
            //if (Contains(worldRect, this.WorldRotation, m.Position))
            //{
                test = Color.Green;
            //}

            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Background != null)
            spriteBatch.Draw(Background, this.WorldPosition, Background.Bounds, test, this.WorldRotation, Vector2.Zero, this.WorldScale, SpriteEffects.None, 0f);
            base.Draw(spriteBatch);
        }
    }
}
