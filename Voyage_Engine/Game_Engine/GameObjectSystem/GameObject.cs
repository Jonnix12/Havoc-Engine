using Voyage_Engine.Game_Engine.TransformSystem;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.GameObjectSystem
{
    public class GameObject : BaseObject, IInstantiate
    {
        private string _name;
        private Transform _transform;
        private bool _isActive;

        public Transform Transform => _transform;
        public bool IsActive => _isActive;

        public string Name
        {
            get { return _name;}
            set
            {
                if (_name.Length == 0)
                {
                    _name = ToString();//need more work
                }
            } }

        
        
        public void SetActive(bool isActive)
        {
            //need active logic
            _isActive = isActive;
        }

        public void Instantiate()
        {
            _transform = new Transform(new Vector2(100, 100), new Vector2(20, 20));
        }

        public void Instantiate(Vector2 position)
        {
            _transform = new Transform(position, Vector2.Zero);
        }

        public void Instantiate(Transform parent)
        {
            _transform = new Transform(parent);
        }

        public void Instantiate(Vector2 position, Vector2 scale)
        {
            _transform = new Transform(position, scale);
        }

        public void Instantiate(Vector2 position, Transform parent)
        {
            _transform = new Transform(position, Vector2.Zero, parent);
        }

        public void Instantiate(Vector2 position, Transform parent, Vector2 scale)
        {
            _transform = new Transform(position, scale, parent);
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }

    public interface IInstantiate
    {
        void Instantiate();
        void Instantiate(Vector2 position);
        void Instantiate(Transform parent);
        void Instantiate(Vector2 position,Vector2 scale);
        void Instantiate(Vector2 position, Transform parent);
        void Instantiate(Vector2 position, Transform parent,Vector2 scale);
    }
}