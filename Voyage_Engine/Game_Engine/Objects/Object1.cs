using Voyage_Engine.Console;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.Objects
{
    public class Object1 : GameObject
    {
        public override void Start()
        {
            base.Start();
            Debug.Log("Hey From Start");
        }
    }
}