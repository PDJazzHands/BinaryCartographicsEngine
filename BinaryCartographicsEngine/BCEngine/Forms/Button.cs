using BinaryCartographicsEngine.BCEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BinaryCartographicsEngine.BCEngine.Input;
using System;

namespace BinaryCartographicsEngine.BCEngine.Forms
{
    class Button : Control
    {
        enum FormButtonState
        {
            NONE,
            HOVER,
            PRESS
        }


        private FormButtonState CurrentState;
        private FormButtonState LastState;

        public Button() { }
        public Button(Transform Parent) : base(Parent) { }
        public Button(Transform Parent, int Width, int Height) : base(Parent, Width, Height) { }

        public Texture2D Background;

        public Color TintColorNone = Color.White;
        public Color TintColorHover = Color.White;
        public Color TintColorPress = Color.White;

        public override void Update()
        {
            MouseEventArgs mouseEventArgs = new MouseEventArgs(InputManager.MouseState);
            Vector2 LocalMousePos = InputManager.MouseState.Position.ToVector2();

            if (Contains(this.LocalBounds, LocalMousePos))  //if mouse is over the button
            {

                 
                if (InputManager.MouseState.LeftButton == ButtonState.Pressed)
                {
                    CurrentState = FormButtonState.PRESS;

                    #region Single Fire Events
                    // if the button was pressed during the current frame, invoke OnMouseDown
                    if (InputManager.OldMouseState.LeftButton == ButtonState.Released)
                        base.OnMousePress(mouseEventArgs);
                    #endregion

                    #region Turbo Click Events
                    // every update, if the mouse is pressed, this will invoke IsMouseDown
                    base.IsMouseDown(mouseEventArgs);
                    #endregion
                }
                else
                {
                   CurrentState = FormButtonState.HOVER;

                    #region Single Fire Events
                    // if the button was released during the current frame, invoke OnMouseUp
                    if (InputManager.OldMouseState.LeftButton == ButtonState.Released)
                        base.OnMouseRelease(mouseEventArgs);

                    // if the button was entered during the current frame, invoke OnMouseEnter 
                    if (!Contains(this.LocalBounds, InputManager.OldMouseState.Position.ToVector2()))
                        base.OnMouseEnter(mouseEventArgs);
                    #endregion

                    #region Turbo Click Events
                    // every update, if the mouse is not pressed, this will invoke IsMouseHover
                    base.IsMouseHover(mouseEventArgs);
                    #endregion*/
                }
            }
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Background != null)
            {
                Rectangle destination = new Rectangle(this.WorldPosition.ToPoint(), this.WorldScale.ToPoint() * new Point(Width, Height));
                spriteBatch.Draw(Background, destination, Background.Bounds, TintColorHover, this.WorldRotation, Vector2.Zero, SpriteEffects.None, 0f);
            }
            base.Draw(spriteBatch);
        }
    }
}
