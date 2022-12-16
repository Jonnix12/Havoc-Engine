using System.Drawing;
using System.Windows.Forms;
using Voyage_Engine.Console;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.InputSystem;

namespace Voyage_Engine.Game_Engine.Objects
{
    public class Player : GameObject
    {
        private Cube cube;

        private float y = 10;
        public override void Start()
        {
            Instantiate();
            cube = new Cube(Transform, Color.Red);
            InputReceiver.OnKeyDown += MoveCube;
            
            Debug.Log(this,true);
            Debug.LogWarning(this);
            Debug.LogError(this);
        }

        public override void Update()
        {


            
        }

        private void MoveCube(Keys keys)
        {
        }
    }
}