using BinaryCartographicsEngine.BCEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BinaryCartographicsEngine.BCEngine.Forms
{
    public class Container : Control
    {


        public List<Control> Controls = new List<Control>();

        public Container() { }
        public Container(Control Parent) : base(Parent) { }

        public override void Update()
        {
            foreach (Control c in Controls)
            {
                c.Update();
            }
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Control c in Controls)
            {
                c.Draw(spriteBatch);
            }
            base.Update();
        }
    }
}
