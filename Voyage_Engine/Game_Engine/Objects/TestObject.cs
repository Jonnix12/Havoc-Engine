using Voyage_Engine.Assest.Sprites;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.Objects
{
    public class TestObject : GameObject
    {
        public override void Start()
        {
            AddComponent<TrianguleSprite>();
            base.Start();
        }

        public override void Update()
        {
            Transform.MoveTowards(new Vector2(500,500),3);
            base.Update();
        }
    }
}