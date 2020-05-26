using System;
using BinaryCartographicsEngine.BCEngine.Input;
using Microsoft.Xna.Framework.Graphics;

namespace BinaryCartographicsEngine.BCEngine.Forms
{
    /// <summary>
    /// The base Control type for all BCForms controls to derive from
    /// See ControlEvents.cs for events and handlers
    /// </summary>
    public partial class Control
    {
        #region Base properties
        public bool IsChild { get; }
        public Control Parent { get; } 
        #endregion

        public Control() { }
        public Control(Control parent)
        {
            IsChild = true;
            Parent = parent;
        }

        public virtual void Update() { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
