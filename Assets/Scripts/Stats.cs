using System;

public static class Stats
{
    public static int Sheeps { get; set; }

    private static int _lifes;
    public static int Lifes
    {
        get => _lifes;
        set
        {
            _lifes = value;
            if (_lifes <= 0)
                LifesEnded?.Invoke();
        }
    }

    public static event Action LifesEnded;

    static Stats() => ToDefault();

    public static void ToDefault()
    {
        Sheeps = 0;
        Lifes = 3;
    }
}
