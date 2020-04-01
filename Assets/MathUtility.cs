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
}
