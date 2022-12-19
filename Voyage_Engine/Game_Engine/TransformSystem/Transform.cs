using Voyage_Engine.Game_Engine.Engine;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.TransformSystem
{
    public class Transform : Node
    {
        private Vector2 _position;
        private Vector2 _scale;
        private GameObject _gameObject;

        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public GameObject GameObject => _gameObject;

        public Vector2 Scale => _scale;

        public bool HaveChildren => Children.Count == 0;

        public Transform()
        {
            _position = Vector2.One;
            _scale = Vector2.One;
            SetParent(MainGameEngine.RootTransform);
        }

        public Transform(Transform parent)
        {
            SetParent(parent);
        }
        
        public Transform(Vector2 position, Vector2 scale)
        {
            _position = position;
            _scale = scale;
            SetParent(MainGameEngine.RootTransform);
        }
        
        public Transform(Vector2 position, Vector2 scale, Transform parent)
        {
            _position = position;
            _scale = scale;
            SetParent(parent);
        }
    }
}