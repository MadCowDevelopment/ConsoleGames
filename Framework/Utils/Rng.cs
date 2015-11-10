using System;

namespace Framework.Utils
{
    public static class Rng
    {
        private static readonly Random Random = new Random((int) DateTime.Now.Ticks);

        public static int Next(int minValue, int maxValue)
        {
            return Random.Next(minValue, maxValue);
        }

        public static int Next(int maxValue)
        {
            return Random.Next(maxValue);
        }
    }
}