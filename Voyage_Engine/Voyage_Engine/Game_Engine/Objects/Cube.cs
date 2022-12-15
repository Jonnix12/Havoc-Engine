using System.Drawing;
using Voyage_Engine.Game_Engine.TransformSystem;
using Voyage_Engine.Rendere_Engine.RenderedObjects;

namespace Voyage_Engine.Game_Engine.Objects
{
    public class Cube : RenderObject
    {
        public Transform _transform;
        private Brushes _color; // need to add sprite
        
        
        
        public Cube(Transform transform, Color color)
        {
            _transform = transform;
        }
        
        public override void Render(Graphics graphics)
        {
            if (_transform == null)
            {
                return;
            }
            
            graphics.FillRectangle(Brushes.Red, _transform.Position.X,_transform.Position.Y,_transform.Scale.X,_transform.Scale.Y);
        }
    }
}