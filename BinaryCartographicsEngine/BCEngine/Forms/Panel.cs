using BinaryCartographicsEngine.BCEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace BinaryCartographicsEngine.BCEngine.Forms
{
    class Panel : Container
    {
        public Panel() { }
        public Panel(Transform Parent) : base(Parent) { }

        public Texture2D Background;
        public Color tint = Color.White;

        public override void Update()
        { 
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Background != null)
                spriteBatch.Draw(Background,this.WorldPosition, Background.Bounds, tint, this.WorldRotation, Vector2.Zero, this.WorldScale, SpriteEffects.None, 0f);
            base.Draw(spriteBatch);
        }
    }
}
