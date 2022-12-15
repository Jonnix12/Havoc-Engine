using Voyage_Engine.Game_Engine.Engine;

namespace Voyage_Engine.Game_Engine.GameObjectSystem
{
    public abstract class BaseObject
    {
        private int InstanceID;

        protected BaseObject()
        {
            MainGameEngine.RegisterObject(this);
            //need to set Instance
        }

        public virtual void Start()
        {
            
        }

        public virtual void Update()
        {
            
        }

        public virtual void LateUpdate()
        {
            
        }
    }
}