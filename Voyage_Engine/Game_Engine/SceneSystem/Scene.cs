using Voyage_Engine.Game_Engine.TransformSystem;

namespace Voyage_Engine.Game_Engine.SceneSystem
{
    public abstract class Scene
    {
        private Transform _rootTransform;

        public Transform RootTransform => _rootTransform;

        public abstract int BuildIndex { get; }

        public Scene()
        {
            _rootTransform = new Transform();
        }
        
        public virtual void StartScene()
        {
            StartChildren(RootTransform);
        }

        public virtual void UpdateScene()
        {
            UpdateChildren(RootTransform);
        }

        public virtual void EndScene()
        {
            
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
    }
}