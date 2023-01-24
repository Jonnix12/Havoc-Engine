using System;
using System.Windows.Forms;
using Voyage_Engine.Rendere_Engine;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.InputSystem
{
    public class InputReceiver : IDisposable
    {
        #region Events

        public static event Action<InputDataMouse> OnMouseDown; 
        public static event Action<InputDataMouse> OnMouseClick; 
        public static event Action<InputDataMouse> OnMouseHold; 
        public static event Action<InputDataMouse> OnMouseUp; 
        /// <summary>
        /// Fires an event once the key is pressed
        /// </summary>
        public static event Action<InputDataKeyboard> OnKeyDown;
        /// <summary>
        /// Fires an event as long as the key is pressed
        /// </summary>
        public static event Action<InputDataKeyboard> OnKeyHold;
        /// <summary>
        /// Fires an event as soon as the key is release
        /// </summary>
        public static event Action<InputDataKeyboard> OnKeyUp;

        #endregion
        
        #region Fields

        private static Canves _canves;
        private static Keys _preesKey;
        private static bool _isKeyDown;
        private static bool _isMouseDown;
        private static bool _isKeyPressedOnesEvent;
        private static bool _isKeyPressedOnesM;//need to get more work

        #endregion

        #region PublicFunction
        
        /// <summary>
        /// Initializes the input system
        /// </summary>
        /// <param name="canves">The window from which the input will be received</param>
        public InputReceiver(Canves canves)
        {
            _canves = canves;
            _canves.KeyDown += InputDown;
            _canves.KeyUp += InputUp;
            _canves.MouseClick += MouseClick;
            _canves.MouseDown += MouseDown;
            _canves.MouseUp += MouseUp;
            _canves.MouseMove += MouseHold;
            _isKeyPressedOnesM = false;
            _isKeyPressedOnesEvent = false;
            _isMouseDown = false;
        }

        /// <summary>
        /// Cleans events and prepares the class for closing
        /// </summary>
        public void Dispose()
        {
            _canves.KeyDown -= InputDown;
            _canves.KeyUp -= InputUp;
            _canves.MouseClick -= MouseClick;
            _canves.MouseDown -= MouseDown;
            _canves.MouseUp -= MouseUp;
            _canves.MouseMove -= MouseHold;
        }
        /// <summary>
        /// A function that checks whether a key on the keyboard is pressed, returns true as long as the key is pressed
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool IsKeyDown(Keys key)
        {
            if (!_isKeyDown)
                return false;

            return key == _preesKey;
        }
        /// <summary>
        /// A function that checks whether a key on the keyboard is pressed, returns true the first time the key is pressed
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool IsKeyPress(Keys key)
        {
            if (!_isKeyDown || _isKeyPressedOnesEvent)
                return false;
            
            _isKeyPressedOnesEvent = true;
            
            return key == _preesKey;
        }
        
        #endregion
        
        
        #region PrivateFunction
        
        private static void MouseClick(object sender, MouseEventArgs e)
        {
            OnMouseClick?.Invoke(new InputDataMouse(e.Button,new Vector2(e.X,e.Y)));
        }
        
        private static void MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = true;
            OnMouseDown?.Invoke(new InputDataMouse(e.Button,new Vector2(e.X,e.Y)));
        }
        
        private static void MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
            OnMouseUp?.Invoke(new InputDataMouse(e.Button,new Vector2(e.X,e.Y)));
        }

        private static void MouseHold(object sender, MouseEventArgs e)
        {
            while (_isMouseDown)
            {
                OnMouseHold?.Invoke(new InputDataMouse(e.Button,new Vector2(e.X,e.Y)));
            }
        }

        private static void InputDown(object sender, KeyEventArgs e)
        {
            _isKeyDown = true;
            _preesKey = e.KeyCode;
            if (!_isKeyPressedOnesM)
            {
                _isKeyPressedOnesM = true;
                OnKeyDown?.Invoke(new InputDataKeyboard(_preesKey));
            }
            
            OnKeyHold?.Invoke(new InputDataKeyboard(_preesKey));
        }
        private static void InputUp(object sender, KeyEventArgs e)
        {
            _isKeyPressedOnesEvent = false;
            _isKeyPressedOnesM = false;
            _isKeyDown = false;
            
            OnKeyUp?.Invoke(new InputDataKeyboard(_preesKey));
            _preesKey = Keys.KeyCode;
        }

        #endregion
    }

    public struct InputDataKeyboard
    {
        private Keys _keysPrees;
        public Keys KeysPrees => _keysPrees;

        public InputDataKeyboard(Keys keys)
        {
            _keysPrees = keys;
        }
    }

    public struct InputDataMouse
    {
        private MouseButtons _mouseButtons;
        private Vector2 _positionOnScreen;
        
        public MouseButtons MouseButtons => _mouseButtons;
        public Vector2 PositionOnScreen => _positionOnScreen;
        
        public InputDataMouse(MouseButtons mouseButtons, Vector2 positionOnScreen)
        {
            _mouseButtons = mouseButtons;
            _positionOnScreen = positionOnScreen;
        }
    }

}