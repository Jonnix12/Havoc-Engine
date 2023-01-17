using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Voyage_Engine.Rendere_Engine.RenderedObjects;
using Voyage_Engine.Rendere_Engine.Vector;
using Debug = Voyage_Engine.Console.Debug;

namespace Voyage_Engine.Rendere_Engine
{
    public class Canves : Form
    {
        public Canves()
        {
            KeyPreview = true;
            DoubleBuffered = true;
        }
    }
    
    public class MainRenderEngine
    {
        public event Action OnBeforeFirstFrame;
        public event Action OnBeforeFrame;
        public event Action OnAfterFrame;
        public event Action OnCloseWindow;
        
        private static List<IRenderable> _renderObjects;
        
        private Vector2 _screenSize;
        private string _windowTitle;
        private Canves _window;
        private Thread _renderLoopThread;

        private bool _sceneInitialized;

        public Canves Window => _window;

        public MainRenderEngine(Vector2 screenSize,string windowTitle)
        {
            _sceneInitialized = false;
            
            _screenSize = screenSize;
            _windowTitle = windowTitle;

            _window = new Canves();
            _window.Size = new Size((int) _screenSize.X, (int) _screenSize.Y);
            _window.Text = _windowTitle;

            FileStream fileStream = File.Open(Application.StartupPath + "/Resources/Engine_Resources/Icon.ico",
                FileMode.Open);
            _window.Icon =  new Icon(fileStream);
            
            fileStream.Close();
            
            _window.Activated += StartRenderLoop;
            _window.FormClosed += CloseRender;
            _window.Paint += Render;

            _renderObjects = new List<IRenderable>();

            _renderLoopThread = new Thread(RenderLoop);
        }

        public void OpenWindow()
        {
            Application.Run(_window);
        }

        private void RenderLoop()
        {
            OnBeforeFirstFrame?.Invoke();

            Stopwatch stopwatch = new Stopwatch();    
            
            while (_renderLoopThread.IsAlive)
            {
                stopwatch.Start();
                OnBeforeFrame?.Invoke();

                _window.BeginInvoke((MethodInvoker) delegate { _window.Refresh(); });
                Thread.Sleep(1);
                
                stopwatch.Stop();
                Time.SetDeltaTime(stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();
                
                OnAfterFrame?.Invoke();
            }
        }

        private static void Render(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            
            graphics.Clear(Color.Aqua);

            for (int i = 0; i < _renderObjects.Count; i++)
            {
                _renderObjects[i].Render(graphics);
            }
        }

        public static void RegisterObject(IRenderable renderable)
        {
            if (_renderObjects.Contains(renderable))
                return;
            
            _renderObjects.Add(renderable);
        }
        
        public static void UnRegisterObject(IRenderable renderable)
        {
            _renderObjects.Remove(renderable);
        }

        private void StartRenderLoop(object sender, EventArgs e)
        {
            if (_renderLoopThread.IsAlive)
                return;
            
            _renderLoopThread.Start();
            Debug.Log("Render Engine starting....");
        }

        private void CloseRender(object sender, FormClosedEventArgs e)
        {
            _window.FormClosed -= CloseRender;
            _window.Activated -= StartRenderLoop;
            _window.Paint -= Render;
            
            OnCloseWindow?.Invoke();
            
            _renderLoopThread.Abort();
            Debug.Log("Render Engine stop...");
        }
    }
}