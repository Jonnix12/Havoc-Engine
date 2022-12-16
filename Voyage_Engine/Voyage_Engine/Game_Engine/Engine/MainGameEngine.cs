using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.InputSystem;
using Voyage_Engine.Game_Engine.Objects;
using Voyage_Engine.Game_Engine.TransformSystem;
using Voyage_Engine.Rendere_Engine;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.Engine
{
    public class MainGameEngine
    {
        private MainRenderEngine _mainRenderEngine;

        private static List<BaseObject> _gameObjects;

        public MainGameEngine()
        {
            _gameObjects = new List<BaseObject>();
            _mainRenderEngine = new MainRenderEngine(new Vector2(500, 500), "Voyage Engine");
            InputReceiver.Init(_mainRenderEngine.Window);
            _mainRenderEngine.OnBeforeFrame += Update;
            _mainRenderEngine.OnBeforeFirstFrame += Start;
            _mainRenderEngine.OnAfterFrame += LateUpdate;
            _mainRenderEngine.OnCloseWindow += ExitEngine;

                
            _mainRenderEngine.OpenWindow();
        }
        
        public static void RegisterObject(BaseObject renderable)
        {
            _gameObjects.Add(renderable);
        }

        private static void Start()
        {
            Player player = new Player();

            foreach (var gameObject in _gameObjects)
            {
                gameObject.Start();
            }
        }

        private static void Update()
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Update();
            }
        }

        private static void LateUpdate()
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.LateUpdate();
            }
        }

        private void ExitEngine()
        {
            _mainRenderEngine.OnBeforeFrame -= Update;
            _mainRenderEngine.OnBeforeFirstFrame -= Start;
            _mainRenderEngine.OnCloseWindow -= ExitEngine;
            _mainRenderEngine.OnAfterFrame -= LateUpdate;
        }
    }
}