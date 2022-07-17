using System;

internal class Planet
{
    internal string velocity;

    public static explicit operator Planet(UnityEngine.Object v)
    {
        throw new NotImplementedException();
    }
}