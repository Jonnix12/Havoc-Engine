using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.Objects;
using Voyage_Engine.Game_Engine.SceneSystem;
using Voyage_Engine.Game_Engine.TileMap;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Assest.Scenes
{
    public class MainScene : Scene
    {
        public override int BuildIndex => 0;
        public override string Name => "MainScene";

        public override void StartScene()
        {
           TileMap tileMap = new TileMap(8, 8,new Vector2(70,70));

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    tileMap[i, j].TryAssiagGameObject(Factory.Instantiate<TestObject>());
                }
            }
            
            base.StartScene();
        }
    }
}