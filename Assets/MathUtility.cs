public static class MathUtility
{
    internal static int Clamp(this int value, int min, int max)
    {
        return (value < min) ? min : (value > max) ? max : value;
    }

    internal static float Clamp(this float value, float min, float max)
    {
        return (value < min) ? min : (value > max) ? max : value;
    }

    internal static int Wrap(int value, int min, int max)
    {
        if (value < min)
            return max;
        if (value > max)
            return min;
        return value;
    }
}
