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
            for (int i = 0; i < 1000000000; i++)
            {
                num = num / 2;
            }
            base.Update();
        }
    }
}