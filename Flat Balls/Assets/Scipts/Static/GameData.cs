using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GameData
{
    public static IList<Line> Lines { get; set; }
    public static IList<Figure> Figures { get; set; }

    private const float MinimalDistance = 1.4f;

    private static readonly Vector2[] FigurePositionVectors =
    {
        new Vector2(0, 1),
        new Vector2(0, -1),
        new Vector2(1, 0),
        new Vector2(-1, 0),
        new Vector2(1, 1),
        new Vector2(-1, 1),
        new Vector2(1, -1),
        new Vector2(-1, -1)
    };

    public static void InitializeData()
    {
        Lines = new List<Line>();
        Figures = new List<Figure>();
        CurrentStatus = Status.Play;
    }

    public static Vector2 GetNewPosition(Vector2 position)
    {
        var newPosition = new Vector2(position.x, position.y);
        var vectors = FigurePositionVectors.ToList();

        while (IsNotOnMinimalDistance(newPosition) && vectors.Any())
        {
            var vector = vectors[Random.Range(0, vectors.Count() - 1)];
            newPosition = position + vector * Random.Range(0.5f, 2f);
            vectors.Remove(vector);
        }
        if (!IsNotOnMinimalDistance(newPosition))
            return newPosition;

        return Vector2.zero;
    }

    private static bool IsNotOnMinimalDistance(Vector2 position)
    {
        return Figures.Any(figure => (Vector2.Distance(figure.Position, position) < MinimalDistance));
    }

    public static Status CurrentStatus { get; set; }

    public static bool IsFiguresConnected(string nameA, string nameB)
    {
        var isConnected = Lines.Any(l => (l.FigureNameA == nameA && l.FigureNameB == nameB)
                                         || (l.FigureNameA == nameB && l.FigureNameB == nameA));
        return isConnected;
    }
}