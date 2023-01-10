using Voyage_Engine.Game_Engine.TransformSystem;

namespace Voyage_Engine.Game_Engine.SceneSystem
{
    public abstract class Scene
    {
        private Transform _rootTransform;

        public Transform RootTransform => _rootTransform;

        public abstract int BuildIndex { get; }
        public abstract string Name { get; }

        public  bool  IsLoaded { get; private set; }

        protected Scene()
        {
            _rootTransform = new Transform();
        }
        
        public virtual void StartScene() //start scene
        {
            StartChildren(RootTransform);
            IsLoaded = true;
        }

        public virtual void UpdateScene() //update scene
        {
            UpdateChildren(RootTransform);
            
        }

        public virtual void EndScene() //end scene
        {
            IsLoaded = false;
        }
        
        private static void StartChildren(Transform transform)
        {
            foreach (var child in transform.Children)
            {
                child.GameObject.Start();
                
                if (child.HaveChildren)
                {
                    StartChildren(child);
                }
            }
        }
        
        private static void UpdateChildren(Transform transform)
        {
            foreach (var child in transform.Children)
            {
                child.GameObject.Update();
                
                if (child.HaveChildren)
                {
                    StartChildren(child);
                }
            }
        }
        public override int GetHashCode()
        {
            return BuildIndex;
        }
    }
}