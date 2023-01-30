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
        private ObjectInput _objectInput = new ObjectInput();

        public override void InitComponent(GameObject gameObject)
        {
            base.InitComponent(gameObject);
            _objectInput.Width = (int)Transform.Scale.X;
            _objectInput.Height = (int)Transform.Scale.Y;

            _objectInput.CreateControl();
            _objectInput.Enabled = true;
            _objectInput.Visible = true;
            _objectInput.Show();
            MainRenderEngine.Windows.AddInputObject(_objectInput);
            if (_objectInput.CanFocus) { _objectInput.Focus(); }

            _objectInput.Click += OnClick;
            _objectInput.DoubleClick += OnDoubleClick;
            _objectInput.MouseClick += OnMouseClick;
            _objectInput.MouseHover += OnMouseHover;
        }

        public override void UpdateComponent()
        {
            base.UpdateComponent();
            _objectInput.Update();
            Point point = new Point((int)Transform.Position.X,(int)Transform.Position.Y);

            _objectInput.Location = point;
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
            _objectInput.Click -= OnClick;
            _objectInput.DoubleClick -= OnDoubleClick;
            _objectInput.MouseClick -= OnMouseClick;
            _objectInput.MouseHover -= OnMouseHover;
        }
    }
}
