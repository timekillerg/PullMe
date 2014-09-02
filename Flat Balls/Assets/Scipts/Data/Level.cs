using System.Collections.Generic;

public class Level
{
    public IList<Figure> Figures { get; set; }
    public IList<Line> Lines { get; set; }

    public Level() { }

    public void InitializeLevel_1()
    {
        Figures = new List<Figure>
        {
            new Figure (1f, 1.5f, 1),
            new Figure (1.5f, 0f, 1),
            new Figure (1f, -1.5f, 1),
            new Figure (-1f, 1.5f, 1),
            new Figure (-1.5f, 0f, 2),
            new Figure (-1f,-1.5f, 2)
        };

        Lines = new List<Line>
        {
            new Line(5,2),
            new Line(5,4),
            new Line(1,2),
            new Line(1,3),
            new Line(4,0),
            new Line(3,0)
        };
    }
}

