using System;
using UnityEngine;

public class Figure
{
    public Figure(float x, float y, int number)
    {
        Vector2 = new Vector2(x,y);
        Number = number;
        Name = Guid.NewGuid().ToString();
    }

    public Figure(Figure figure)
    {
        Vector2 = new Vector2(figure.Vector2.x, figure.Vector2.y);
        Number = figure.Number;
        Name = Guid.NewGuid().ToString();
    }

    public int Number { get; set; }

    public string Name { get; set; }

    public Vector2 Vector2 { get; set; }

    public bool IsTriedToDevide { get; set; }

    public GameObject GameObject { get; set; }
}
