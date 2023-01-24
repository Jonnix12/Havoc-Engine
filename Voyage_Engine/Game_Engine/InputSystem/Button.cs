using System;
using System.Windows.Forms;
using Voyage_Engine.Console;
using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.TransformSystem;

namespace Voyage_Engine.Game_Engine.InputSystem
{
    public class Button : Component, IDisposable
    {
        Control control = new Control();
        public Button()
        {
            control.Width = (int)Transform.Scale.X;
            control.Height = (int)Transform.Scale.Y;

            control.Click += OnClick;
            control.DoubleClick += OnDoubleClick;
            control.MouseClick += OnMouseClick;
            control.MouseHover += OnMouseHover;
        }

        public virtual void OnClick(object sender, EventArgs e)
        {
            Debug.Log("Clicked!");
        }

        public virtual void OnDoubleClick(object sender, EventArgs e)
        {
            Debug.Log("Double Clicked!");
        }

        public virtual void OnMouseClick(object sender, EventArgs e)
        {
            Debug.Log("Mouse Clicked");
        }

        public virtual void OnMouseHover(object sender, EventArgs e)
        {
            Debug.Log("Mouse Hover!");
        }

         void IDisposable.Dispose()
        {
            control.Click -= OnClick;
            control.DoubleClick -= OnDoubleClick;
            control.MouseClick -= OnMouseClick;
            control.MouseHover -= OnMouseHover;
        }
    }
}
