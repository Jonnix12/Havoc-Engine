using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.TransformSystem
{
    public class Transform : Node
    {
        private Vector2 _position;
        private Vector2 _scale;

        public Vector2 Position
        {
            get { return _position;}
            set { _position = value; }
        }

        public Vector2 Scale => _scale;

        public Transform()
        {
            _position = Vector2.One;
            _scale = Vector2.One;
        }
        
        public Transform(Transform parent)
        {
            SetParent(parent);
        }
        
        public Transform(Vector2 position, Vector2 scale)
        {
            _position = position;
            _scale = scale;
        }
        
        public Transform(Vector2 position, Vector2 scale, Transform parent)
        {
            _position = position;
            _scale = scale;
            SetParent(parent);
        }
    }
}