using System;

namespace Voyage_Engine.Rendere_Engine.Vector
{
    public struct Vector2
    {
        private float _x;
        private float _y;
        private float _magnitude;

        public float X => _x;

        public float Y => _y;

        public float Magnitude => _magnitude;

        public Vector2(float x , float y)
        {
            _x = x;
            _y = y;
            _magnitude = 1;
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

        public static float Distance(Vector2 pointA, Vector2 pointB)
        {
            var a = Math.Abs(pointA.X - pointB.X);
            var b = Math.Abs(pointA.Y - pointB.Y);

            return (float)Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }

        public void MoveTowards(Vector2 current, Vector2 destination, float maxDistanceDelta)
        {
            
        }

        public override string ToString()
        {
            return $" X:{X},Y:{Y} ";
        }
    }
}