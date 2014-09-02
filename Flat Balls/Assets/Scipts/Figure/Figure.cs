using System;
using UnityEngine;

public class Figure
{
    public Figure(float x, float y, int number)
    {
        X = x;
        Y = y;
        Number = number;
        Name = Guid.NewGuid().ToString();
    }

    public Figure(Figure figure)
    {
        X = figure.X;
        Y = figure.Y;
        Number = figure.Number;
        Name = Guid.NewGuid().ToString();
    }

    public float X { get; set; }

    public float Y { get; set; }

    public int Number { get; set; }

    public string Name { get; set; }

    public bool IsTriedToDevide { get; set; }

    public GameObject GameObject { get; set; }

    public Vector2 Position
    {
        get { return new Vector2(X, Y); }
        set
        {
            X = value.x;
            Y = value.y;
        }
    }
}
