using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public sealed class RangeExAttribute : PropertyAttribute
{
    public readonly int Min;
    public readonly int Max;
    public readonly float Step;

    public RangeExAttribute(int min, int max, float step)
    {
        Min = min;
        Max = max;
        Step = step;
    }
}