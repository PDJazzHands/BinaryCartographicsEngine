using BinaryCartographicsEngine.BCEngine.Input;
using BinaryCartographicsEngine.BCEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BinaryCartographicsEngine.BCEngine.Forms
{
    public class ControlBase : Transform
    {
        public RenderTarget2D RenderTarget;
        public Game Game;
        public GraphicsDevice Graphics;
        public ControlBase(GraphicsDevice Graphics)
        {
            this.Graphics = Graphics;
        }
        public ControlBase(GraphicsDevice Graphics, int Width, int Height)
        {
            this.Graphics = Graphics;
            this.Width = Width;
            this.Height = Height;
            localBounds = new Rectangle(0, 0, Width, Height);
            RenderTarget = new RenderTarget2D(Graphics, Width, Height);
        }
        public ControlBase(GraphicsDevice Graphics, Transform Parent, int Width, int Height) : base(Parent)
        {
            this.Graphics = Graphics;
            this.Width = Width;
            this.Height = Height;
            localBounds = new Rectangle(0, 0, Width, Height);
            RenderTarget = new RenderTarget2D(Graphics, Width, Height);
        }
        public ControlBase(Transform Parent) : base(Parent) { }

        public virtual void Update() { }
        public virtual void Draw(SpriteBatch spriteBatch) { }

        private Rectangle localBounds;
        public Rectangle LocalBounds { get { return localBounds; } set { localBounds = value; } }
        public int Width
        {
            get { return localBounds.Width; }
            set { localBounds = new Rectangle(localBounds.Location, new Point(value, localBounds.Height)); }
        }
        public int Height
        {
            get { return localBounds.Height; }
            set { localBounds = new Rectangle(localBounds.Location, new Point(localBounds.Width, value)); }
        }

        public bool Contains(Rectangle LocalRect, Vector2 WorldPoint)
        {
            // rotate around rectangle center by -rectAngle
            Vector2 WorldToLocal = InverseTransformVector(WorldPoint);
            return LocalRect.Contains(WorldToLocal);
        }

        #region Mouse events and handlers
        /// <summary>
        /// One shot Mouse events 
        /// </summary>
        // Mouse button was pressed down
        public event EventHandler MousePressHandler;
        public virtual void OnMousePress(MouseEventArgs e)
        {
            MousePressHandler?.Invoke(this, e);
        }
        // Mouse button was released
        public event EventHandler MouseReleaseHandler;
        public virtual void OnMouseRelease(MouseEventArgs e)
        {
            MouseReleaseHandler?.Invoke(this, e);
        }
        // Mouse begun hovering over a control
        public event EventHandler MouseEnterHandler;
        public virtual void OnMouseEnter(MouseEventArgs e)
        {
            MouseEnterHandler?.Invoke(this, e);
        }
        // Mouse stopped hovering over a control
        public event EventHandler MouseLeaveHandler;
        public virtual void OnMouseLeave(MouseEventArgs e)
        {
            MouseLeaveHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Turbo charged crackhead Mouse events
        /// </summary>
        // Mouse button is currently down
        public event EventHandler MouseDownHandler;
        public virtual void IsMouseDown(MouseEventArgs e)
        {
            MouseDownHandler?.Invoke(this, e);
        }
        // Mouse cursor is currently over a control
        public event EventHandler MouseHoverHandler;
        public virtual void IsMouseHover(MouseEventArgs e)
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
        protected virtual void OnKeyPress(KeyEventArgs e)
        {
            KeyPressHandler?.Invoke(this, e);
        }
        // Key was released
        public event EventHandler KeyReleaseHandler;
        protected virtual void OnKeyRelease(KeyEventArgs e)
        {
            KeyReleaseHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Turbo charged crackhead Key events 
        /// </summary>
        // Key is currently down
        public event EventHandler KeyDownHandler;
        protected virtual void IsKeyDown(KeyEventArgs e)
        {
            KeyDownHandler?.Invoke(this, e);
        }
        // Key is currently up
        public event EventHandler KeyUpHandler;
        protected virtual void IsKeyUp(KeyEventArgs e)
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
        protected virtual void OnControlAdded(KeyEventArgs e)
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
