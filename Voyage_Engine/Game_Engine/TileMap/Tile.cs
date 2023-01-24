using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.TileMap
{
    public abstract class Tile 
    {
        Vector2 size;
        Vector2 pos;
        GameObject tileObject;
        public int row { get; set; }
        public int colm { get; set; }

        public bool tryAssiagedGameObject(GameObject gameobject)
        {
            if(tileObject != null)
            {
                return false;
            }

            tileObject = gameobject;

            tileObject.Transform.Position = pos;
            tileObject.Transform.Scale = size;

            return true;
        }

        public GameObject RemoveTileObject()
        {
            if(tileObject != null)
            {
                var cache = tileObject;
                tileObject = null;

                return cache;
            }

            return null;
        }

      //  protected List<TileObject> objects;
       
    }
}


