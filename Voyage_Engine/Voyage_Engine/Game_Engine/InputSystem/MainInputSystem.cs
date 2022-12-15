using System;
using System.Windows.Forms;
using Voyage_Engine.Rendere_Engine;


namespace Voyage_Engine.Game_Engine.InputSystem
{
    public static class MainInputSystem
    {
        public static event Action<Keys> OnKeyDown;
        public static event Action<Keys> OnKeyUp;
        
        public static void CheckInput(Canves canves)
        {
            canves.KeyDown += InputDown;
            canves.KeyUp += InputUp;
        }

        private static void InputDown(object sender, KeyEventArgs e)
        { 
            OnKeyDown?.Invoke(e.KeyCode);
        }
        
        private static void InputUp(object sender, KeyEventArgs e)
        {
            OnKeyUp?.Invoke(e.KeyCode);
        }
    }
}