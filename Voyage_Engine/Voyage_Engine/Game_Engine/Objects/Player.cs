using System;
using System.Drawing;
using System.Windows.Forms;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.InputSystem;
using Voyage_Engine.Rendere_Engine.Vector;

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
            MainInputSystem.OnKeyDown += MoveCube;
        }

        public override void Update()
        {
            
        }

        private void MoveCube(Keys keys)
        {
            if (keys == Keys.A)
            {
                y += 1;
                cube._transform.Position = new Vector2(cube._transform.Position.X, y);
            }
        }
    }
}