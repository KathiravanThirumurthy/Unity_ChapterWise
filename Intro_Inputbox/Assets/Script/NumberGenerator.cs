using UnityEngine;

public static class NumberGenerator
{
    public static int GenerateRandomNumber(int minValue, int maxValue)
    {
        return Random.Range(minValue, maxValue + 1);
    }
}
