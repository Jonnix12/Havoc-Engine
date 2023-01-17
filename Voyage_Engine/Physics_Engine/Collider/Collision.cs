using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voyage_Engine.Console;
using Voyage_Engine.Rendere_Engine.Vector;
using Voyage_Engine.Game_Engine.TransformSystem;
using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Physics_Engine.Collision
{
    internal class Collider : Component
    {
        private Bounds _bounds;

        Line[] lines = new Line[4];

        public Line UpperLine => lines[0];
        public Line LeftLine => lines[1];
        public Line RightLine => lines[2];
        public Line BottomLine => lines[3];

        public Collider(Transform transform)
        {
            if (transform == null)
                throw new Exception("Collider: Cant create collider without Transform");

            lines[0] = new Line("Upper Line", transform.Position, new Vector2(transform.Scale.X, transform.Position.Y));
            lines[1] = new Line("Left Line", transform.Position, new Vector2(transform.Position.X, transform.Scale.Y));
            lines[2] = new Line("Right Line", new Vector2(transform.Scale.X, transform.Position.Y), new Vector2(transform.Scale.X, transform.Scale.Y));
            lines[3] = new Line("Bottom Line", new Vector2(transform.Position.X, transform.Scale.Y), new Vector2(transform.Scale.X, transform.Scale.Y));
        }

        public override void InitComponent(GameObject gameObject)
        {
            base.InitComponent(gameObject);
            new Collider(Transform);
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
