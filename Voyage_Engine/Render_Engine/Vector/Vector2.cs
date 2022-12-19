namespace Voyage_Engine.Rendere_Engine.Vector
{
    public struct Vector2
    {
        private float _x;
        private float _y;

        public float X => _x;

        public float Y => _y;

        public Vector2(float x , float y)
        {
            _x = x;
            _y = y;
        }

        public static Vector2 Zero => new Vector2(0, 0);
        public static Vector2 One => new Vector2(1, 1);

        public static Vector2 Down => new Vector2(0, -1);
        
        public static Vector2 Up => new Vector2(0, 1);
        
        public static Vector2 Left => new Vector2(-1, 0);

        public static Vector2 Right => new Vector2(1, 0);
        
        public static Vector2 Add(Vector2 vectorOne, Vector2 vectorTwo)
        {
            var x = vectorOne.X + vectorTwo.X;
            var y = vectorOne.Y + vectorTwo.Y;

            return new Vector2(x, y);
        }
    }
}