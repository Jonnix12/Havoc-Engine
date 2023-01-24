using System;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using Voyage_Engine.Console;
using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.TransformSystem;
using Voyage_Engine.Physics_Engine.Collision;
using Voyage_Engine.Rendere_Engine;

namespace Voyage_Engine.Game_Engine.InputSystem
{
    public class Button : Component, IDisposable
    {
        ObjectInput control;
        public override void InitComponent(GameObject gameObject)
        {
            control = new ObjectInput();
            control.CreateControl();
            control.Enabled= true;
            control.Visible = true;
            System.Console.WriteLine(control.IsHandleCreated); 
            control.Focus();
            
            if(control.CanFocus) { control.Focus(); }
            base.InitComponent(gameObject);
            control.Width = (int)Transform.Scale.X;
            control.Height = (int)Transform.Scale.Y;
            control.Click += OnClick;
            control.DoubleClick += OnDoubleClick;
            control.MouseClick += OnMouseClick;
            control.MouseHover += OnMouseHover;
        }

        public override void UpdateComponent()
        {
            base.UpdateComponent();
            control.Update();
            Point point = new Point((int)Transform.Position.X,(int)Transform.Position.Y);

            control.Location = point;
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
