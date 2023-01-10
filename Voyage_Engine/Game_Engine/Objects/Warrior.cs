﻿using Voyage_Engine.Assest.Sprites;
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
            AddComponent<WarriorSprite>();
            var d = Vector2.Distance(Transform.Position, new Vector2(70, 70));
            Debug.Log(d);
            base.Start();
        }

        public override void Update()
        {
            //Debug.Log(Time.DeltaTime);
            
            //Transform.MoveTowards(new Vector2(1000,1000));
            base.Update();
        }

        private void OnMouseClock(InputDataMouse inputDataMouse)
        {
            Debug.Log("Hey Form Mouse click");
        }
    }
}