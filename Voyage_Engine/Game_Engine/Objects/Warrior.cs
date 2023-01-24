using System.Windows.Forms;
using Voyage_Engine.Assest.Sprites;
using Voyage_Engine.Console;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.InputSystem;
using Voyage_Engine.Game_Engine.SceneSystem;
using Voyage_Engine.Physics_Engine.Collision;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.Objects
{
    public class Warrior : GameObject
    {
        public override void Start()
        {
            AddComponent<WarriorSprite>();
            AddComponent<Collider>();
            //AddComponent<InputSystem.Button>();
            var d = Vector2.Distance(Transform.Position, new Vector2(70, 70));
            Debug.Log(d);
            base.Start();
        }

        public override void Update()
        {
            if (InputReceiver.IsKeyDown(Keys.F))
            {
                SceneManager.NextScene();
            }
            
            
            Transform.MoveTowards(new Vector2(50,500),3);
            base.Update();
        }

        private void OnMouseClock(InputDataMouse inputDataMouse)
        {
            Debug.Log("Hey Form Mouse click");
        }
    }
}