using System;
using System.Windows.Forms;
using Voyage_Engine.Rendere_Engine;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.InputSystem
{
    public class InputReceiver
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
        public static void Init(Canves canves)
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
        
        /// <summary>
        /// Cleans events and prepares the class for closing
        /// </summary>
        public static void Dispose()
        {
            _canves.KeyDown -= InputDown;
            _canves.KeyUp -= InputUp;
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

            return CheckInputType(key);
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
            return CheckInputType(key);
        }
        
        #endregion
        
        
        #region PrivateFunction

        private static void InputDown(object sender, KeyEventArgs e)
        {
            _isKeyDown = true;

            if (!_isKeyPressedOnesM)
            {
                _isKeyPressedOnesM = true;
                OnKeyDown?.Invoke(new InputDataKeyboard(e.KeyCode));
            }
            
            OnKeyHold?.Invoke(new InputDataKeyboard(e.KeyCode));
        }
        private static void InputUp(object sender, KeyEventArgs e)
        {
            _isKeyPressedOnesEvent = false;
            _isKeyPressedOnesM = false;
            _isKeyDown = false;
            OnKeyUp?.Invoke(new InputDataKeyboard(e.KeyCode));
        }
        private static bool CheckInputType(Keys key)
        {
             switch (key)
            {
                case Keys.Left:
                    return true;
                case Keys.Up:
                    return true;
                case Keys.Right:
                    return true;
                case Keys.Down:
                    return true;
                case Keys.A:
                    return true;
                case Keys.B:
                    return true;
                case Keys.C:
                    return true;
                case Keys.D:
                    return true;
                case Keys.E:
                    return true;
                case Keys.F:
                    return true;
                case Keys.G:
                    return true;
                case Keys.H:
                    return true;
                case Keys.I:
                    return true;
                case Keys.J:
                    return true;
                case Keys.K:
                    return true;
                case Keys.L:
                    return true;
                case Keys.M:
                    return true;
                case Keys.N:
                    return true;
                case Keys.O:
                    return true;
                case Keys.P:
                    return true;
                case Keys.Q:
                    return true;
                case Keys.R:
                    return true;
                case Keys.S:
                    return true;
                case Keys.T:
                    return true;
                case Keys.U:
                    return true;
                case Keys.V:
                    return true;
                case Keys.W:
                    return true;
                case Keys.X:
                    return true;
                case Keys.Y:
                    return true;
                case Keys.Z:
                    return true;
                case Keys.KeyCode:
                    return true;
                case Keys.Modifiers:
                    return true;
                case Keys.None:
                    return true;
                case Keys.LButton:
                    return true;
                case Keys.RButton:
                    return true;
                case Keys.Cancel:
                    return true;
                case Keys.MButton:
                    return true;
                case Keys.XButton1:
                    return true;
                case Keys.XButton2:
                    return true;
                case Keys.Back:
                    return true;
                case Keys.Tab:
                    return true;
                case Keys.LineFeed:
                    return true;
                case Keys.Clear:
                    return true;
                case Keys.Return:
                    return true;
                case Keys.ShiftKey:
                    return true;
                case Keys.ControlKey:
                    return true;
                case Keys.Menu:
                    return true;
                case Keys.Pause:
                    return true;
                case Keys.Capital:
                    return true;
                case Keys.KanaMode:
                    return true;
                case Keys.JunjaMode:
                    return true;
                case Keys.FinalMode:
                    return true;
                case Keys.HanjaMode:
                    return true;
                case Keys.Escape:
                    return true;
                case Keys.IMEConvert:
                    return true;
                case Keys.IMENonconvert:
                    return true;
                case Keys.IMEAccept:
                    return true;
                case Keys.IMEModeChange:
                    return true;
                case Keys.Space:
                    return true;
                case Keys.Prior:
                    return true;
                case Keys.Next:
                    return true;
                case Keys.End:
                    return true;
                case Keys.Home:
                    return true;
                case Keys.Select:
                    return true;
                case Keys.Print:
                    return true;
                case Keys.Execute:
                    return true;
                case Keys.Snapshot:
                    return true;
                case Keys.Insert:
                    return true;
                case Keys.Delete:
                    return true;
                case Keys.Help:
                    return true;
                case Keys.D0:
                    return true;
                case Keys.D1:
                    return true;
                case Keys.D2:
                    return true;
                case Keys.D3:
                    return true;
                case Keys.D4:
                    return true;
                case Keys.D5:
                    return true;
                case Keys.D6:
                    return true;
                case Keys.D7:
                    return true;
                case Keys.D8:
                    return true;
                case Keys.D9:
                    return true;
                case Keys.LWin:
                    return true;
                case Keys.RWin:
                    return true;
                case Keys.Apps:
                    return true;
                case Keys.Sleep:
                    return true;
                case Keys.NumPad0:
                    return true;
                case Keys.NumPad1:
                    return true;
                case Keys.NumPad2:
                    return true;
                case Keys.NumPad3:
                    return true;
                case Keys.NumPad4:
                    return true;
                case Keys.NumPad5:
                    return true;
                case Keys.NumPad6:
                    return true;
                case Keys.NumPad7:
                    return true;
                case Keys.NumPad8:
                    return true;
                case Keys.NumPad9:
                    return true;
                case Keys.Multiply:
                    return true;
                case Keys.Add:
                    return true;
                case Keys.Separator:
                    return true;
                case Keys.Subtract:
                    return true;
                case Keys.Decimal:
                    return true;
                case Keys.Divide:
                    return true;
                case Keys.F1:
                    return true;
                case Keys.F2:
                    return true;
                case Keys.F3:
                    return true;
                case Keys.F4:
                    return true;
                case Keys.F5:
                    return true;
                case Keys.F6:
                    return true;
                case Keys.F7:
                    return true;
                case Keys.F8:
                    return true;
                case Keys.F9:
                    return true;
                case Keys.F10:
                    return true;
                case Keys.F11:
                    return true;
                case Keys.F12:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException(nameof(key), key, "Not support KeyCode");
            }
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