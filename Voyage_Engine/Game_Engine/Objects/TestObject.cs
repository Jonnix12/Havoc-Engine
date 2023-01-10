using System;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.Objects
{
    public class TestObject : GameObject
    {
        private Random _random = new Random();
        private double num;

        public override void Start()
        {
            num = _random.Next();
            base.Start();
        }

        public override void Update()
        {
            
            base.Update();
        }
    }
}