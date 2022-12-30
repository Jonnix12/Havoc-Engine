using Voyage_Engine.Console;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.TransformSystem;

namespace Voyage_Engine.Game_Engine.ComponentSystem
{
    public class Component : BaseObject , IComponent
    {
        private Transform _transform;
        private GameObject _gameObject;

        public Transform Transform => _transform;

        public GameObject GameObject => _gameObject;

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public virtual void InitComponent(GameObject gameObject)
        {
            InitializedBaseObject();
            
            _gameObject = gameObject;
            _transform = gameObject.Transform;
        }

        public virtual void UpdateComponent()
        {
        }
    }
}