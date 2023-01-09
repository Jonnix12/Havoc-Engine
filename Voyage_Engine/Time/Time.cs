namespace Voyage_Engine
{
    public static class Time
    {
        private static double _deltaTime;

        public static double DeltaTime => _deltaTime / 1000;

        public static void SetDeltaTime(double time)
        {
            _deltaTime = time;
        }
    }
}