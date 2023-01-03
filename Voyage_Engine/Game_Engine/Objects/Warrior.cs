using System.Windows.Forms;
using Voyage_Engine.Assest.Sprites;
using Voyage_Engine.Console;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.InputSystem;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.Objects
{
    public class Warrior : GameObject
    {
        public override void Start()
        {
            Debug.Log(Application.StartupPath);
            AddComponent<WarriorSprite>();
            base.Start();
        }

        public override void Update()
        {
            if (InputReceiver.IsKeyDown(Keys.A))
            {
                Transform.Position = new Vector2(Transform.Position.X - 10, Transform.Position.Y);
            }
            
            if (InputReceiver.IsKeyDown(Keys.D))
            {
                Transform.Position = new Vector2(Transform.Position.X + 10, Transform.Position.Y);

            }
            
            if (InputReceiver.IsKeyDown(Keys.S))
            {
                Transform.Position = new Vector2(Transform.Position.X, Transform.Position.Y + 10);

            }
            
            if (InputReceiver.IsKeyDown(Keys.W))
            {
                Transform.Position = new Vector2(Transform.Position.X, Transform.Position.Y - 10);

            }
            base.Update();
        }

        private void OnMouseClock(InputDataMouse inputDataMouse)
        {
            Debug.Log("Hey Form Mouse click");
        }
    }
}