using System;
using System.Windows.Forms;
using Voyage_Engine.Game_Engine.InputSystem;
using Voyage_Engine.Game_Engine.ResourcesSystem;
using Voyage_Engine.Game_Engine.SceneSystem;
using Voyage_Engine.Game_Engine.TransformSystem;
using Voyage_Engine.Rendere_Engine;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.Engine
{
    public class MainGameEngine
    {
        public event Action OnEndUpdate;

        public static string MainPath => Application.StartupPath;

        private MainRenderEngine _mainRenderEngine;
        
        public static Scene CurrentScene => SceneManager.CurrentScene;

        public static Transform RootTransform => CurrentScene.RootTransform;

        private InputReceiver _input;
        private Resources _resources;

        public MainGameEngine()
        {
            _mainRenderEngine = new MainRenderEngine(new Vector2(1000, 1000), "Voyage Engine");
            _input = new InputReceiver(_mainRenderEngine.Window);
            _resources = new Resources();
            
            _mainRenderEngine.OnBeforeFrame += Update;
            _mainRenderEngine.OnBeforeFirstFrame += Start;
            _mainRenderEngine.OnAfterFrame += LateUpdate;
            _mainRenderEngine.OnCloseWindow += ExitEngine;
           
            
            _mainRenderEngine.OpenWindow();
        }

        private static void Start()
        {
            SceneManager.SetFirstScene();
            
            SceneManager.CurrentScene.StartScene();
        }

        private static void Update()
        {
            SceneManager.CurrentScene.UpdateScene();
        }

        private static void LateUpdate()
        {
            
        }

        private void ExitEngine()
        {
            _mainRenderEngine.OnBeforeFrame -= Update;
            _mainRenderEngine.OnBeforeFirstFrame -= Start;
            _mainRenderEngine.OnCloseWindow -= ExitEngine;
            _mainRenderEngine.OnAfterFrame -= LateUpdate;
            
            _input.Dispose();
        }
    }

    interface IInitialized : IDisposable
    {
        void Init();
    }
}