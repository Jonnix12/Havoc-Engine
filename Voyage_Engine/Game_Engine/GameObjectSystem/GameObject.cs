using System;
using System.Collections.Generic;
using Voyage_Engine.Console;
using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.TransformSystem;

namespace Voyage_Engine.Game_Engine.GameObjectSystem
{
    public abstract class GameObject : BaseObject , IInstantiate , IGameObject, IDisposable
    {
        private string _name;
        private Transform _transform;
        private bool _isActive;
        
        private List<IComponent> _components;
        
        public string Name => _name;
        public Transform Transform => _transform;
        public bool IsActive => _isActive;


        /// <summary>
        /// Gets the component constructor of the GameObject
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public GameObject GameObjectConstructor(Transform transform,string name)
        {
            InitializedBaseObject();

            _components = new List<IComponent>();
            
            transform.SetGameObject(this);

            _name = name;

            _transform = transform;

            return this;
        }

        /// <summary>
        /// Adds a component class of type componentType to the game object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="findObject"></param>
        /// <returns></returns>
        public T AddComponent<T>() where T : IComponent , new()
        {
            T component = new T();
            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i].Equals(component))
                {
                    Debug.LogWarning($"{_name}: You are trying to add a component that already exists");
                    return default(T);
                }
                else
                    continue;
            }
            _components.Add(component);
            return component;
        }

        /// <summary>
        /// Remove a component class of type componentType to the game object, if it exists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="findObject"></param>
        /// <returns></returns>
        public void RemoveComponent<T>(T removedObject) where T : IComponent
        {
            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i].Equals(removedObject))
                {
                    _components.Remove(removedObject);
                }
            }
            Debug.LogError($"{_name}: The component you are trying to remove is not found on this object");
        }

        /// <summary>
        /// Activates/Deactivates the GameObject, depending on the given true or false value.
        /// </summary>
        /// <param name="isActive"></param>
        public void SetActive(bool isActive)
        {
            //need active logic
            _isActive = isActive;
        }
        
        public override string ToString()
        {
            return GetType().Name;
        }

        public virtual void Start()
        {
            foreach (var component in _components)
                component.InitComponent(this);
        }

        public virtual void Update()
        {
            foreach (var component in _components)
                component.UpdateComponent();
        }

        public virtual void LateUpdate()
        {
            
        }

        /// <summary>
        /// Gets the component of the specified type, if it exists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="findObject"></param>
        /// <returns></returns>
        public virtual T GetComponent<T>(T findObject) where T : IComponent
        {
            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i].Equals(findObject))
                {
                    return (T)findObject;
                }
            }
            Debug.LogError($"{_name}: The component you are trying to get is not found on this object");
            return default(T);
        }

        public abstract void Dispose();
    }
}