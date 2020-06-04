using System;
using BinaryCartographicsEngine.BCEngine.Input;
using BinaryCartographicsEngine.BCEngine.Math;
using Microsoft.Xna.Framework.Graphics;

namespace BinaryCartographicsEngine.BCEngine.Forms
{
    /// <summary>
    /// The base Control type for all BCForms controls to derive from
    /// See ControlEvents.cs for events and handlers
    /// </summary>
    public partial class Control
    {
        public Transform Transform;
        public Transform LocalTransform
        {
            get { return Transform; }
        }
        public Transform WorldTransform
        {
            get
            {
                return IsChild ?
                Transform.Compose(Transform, Parent.Transform) :
                Transform;
            }
        }


        #region Base properties
        public bool IsChild { get; }
        public Control Parent { get; } 
        public bool IsEnabled { get; }
        #endregion

        public Control() { }
        public Control(Control parent)
        {
            IsChild = true;
            Parent = parent;
        }

        public virtual void Update() { }
        public virtual void Draw(SpriteBatch spriteBatch) { }

        #region Mouse events and handlers
        /// <summary>
        /// One shot Mouse events 
        /// </summary>
        // Mouse button was pressed down
        public event EventHandler MousePressHandler;
        protected void OnMousePress(MouseEventArgs e)
        {
            MousePressHandler?.Invoke(this, e);
        }
        // Mouse button was released
        public event EventHandler MouseReleaseHandler;
        protected void OnMouseRelease(MouseEventArgs e)
        {
            MouseReleaseHandler?.Invoke(this, e);
        }
        // Mouse begun hovering over a control
        public event EventHandler MouseEnterHandler;
        protected void OnMouseEnter(MouseEventArgs e)
        {
            MouseEnterHandler?.Invoke(this, e);
        }
        // Mouse stopped hovering over a control
        public event EventHandler MouseLeaveHandler;
        protected void OnMouseLeave(MouseEventArgs e)
        {
            MouseLeaveHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Turbo charged crackhead Mouse events
        /// </summary>
        // Mouse button is currently down
        public event EventHandler MouseDownHandler;
        protected void IsMouseDown(MouseEventArgs e)
        {
            MouseDownHandler?.Invoke(this, e);
        }
        // Mouse cursor is currently over a control
        public event EventHandler MouseHoverHandler;
        protected void IsMouseHover(MouseEventArgs e)
        {
            MouseHoverHandler?.Invoke(this, e);
        }
        #endregion

        #region Key events and handlers
        /// <summary>
        /// One shot Key events 
        /// </summary
        // key was pressed down
        public event EventHandler KeyPressHandler;
        protected void OnKeyPress(KeyEventArgs e)
        {
            KeyPressHandler?.Invoke(this, e);
        }
        // Key was released
        public event EventHandler KeyReleaseHandler;
        protected void OnKeyRelease(KeyEventArgs e)
        {
            KeyReleaseHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Turbo charged crackhead Key events 
        /// </summary>
        // Key is currently down
        public event EventHandler KeyDownHandler;
        protected void IsKeyDown(KeyEventArgs e)
        {
            KeyDownHandler?.Invoke(this, e);
        }
        // Key is currently up
        public event EventHandler KeyUpHandler;
        protected void IsKeyUp(KeyEventArgs e)
        {
            KeyUpHandler?.Invoke(this, e);
        }
        #endregion

        #region Gamepad events and handlers ( NOT IMPLEMENTED )
        /// <summary>
        /// One shot Gamepad events 
        /// </summary>

        ///TODO: implement gamepad input and solve for BCForms input methods

        /// <summary>
        /// Turbo charged crackhead Gamepad events 
        /// </summary>
        #endregion

        #region Control events and handlers ( NOT IMPLEMENTED )
        /// <summary>
        /// One shot Control events 
        /// </summary>
        public event EventHandler OnControlAddedHandler;
        protected void OnControlAdded(KeyEventArgs e)
        {
            OnControlAddedHandler?.Invoke(this, e);
        }
        ///TODO: implement Control based events

        /// <summary>
        /// Turbo charged crackhead Control events 
        /// </summary>
        #endregion
    }
}
