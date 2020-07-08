using UnityEngine;
using UnityEngine.UI;

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

    public static int Truncate(float d)
    {
        string s = d.ToString();
        int output;
        if (s.IndexOf('.') > 0)
        {
            output = int.Parse(s.Substring(0, s.IndexOf('.')));
        }
        else
        {
            output = int.Parse(s);
        }

        return output;
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

public static class GUIUtility
{
    public static void DimGUI(Transform t, float alpha = 0.7f)
    {
        foreach (Transform child in t)
            DimGUI(child, alpha);

        Color co;
        Image im = t.GetComponent<Image>();
        Text tx = t.GetComponent<Text>();

        if (im != null)
        {
            co = im.color;
            co.a = alpha;
            im.color = co;
        }

        if (tx != null)
        {
            co = tx.color;
            co.a = alpha;
            tx.color = co;
        }
    }
}