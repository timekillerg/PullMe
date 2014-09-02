public class Line
{
    public Line(int idA, int idB)
    {
        FigureIdA = idA;
        FigureIdB = idB;
    }

    public Line(string nameA, string nameB)
    {
        FigureNameA = nameA;
        FigureNameB = nameB;
    }

    public Line() { }

    public string FigureNameA { get; set; }
    public string FigureNameB { get; set; }

    public int FigureIdA { get; set; }
    public int FigureIdB { get; set; }
}
