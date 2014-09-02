using System.Linq;
using UnityEngine;
using System.Collections;

public class FiguresGenerator : MonoBehaviour
{
    public GameObject FigureGameObject;
    public GameObject LineGameObject;
    public GameObject ParentFigure;
    private bool _isGeneration = false;

    private int _generatonSubStep = 4;

    public void Start()
    {
        _isGeneration = false;
        GameData.InitializeData();
        GameData.Figures.Add(new Figure(0, 0, 2));
    }

    void Update()
    {
        if (GameData.Figures != null && GameData.Figures.Count() == 1 && !_isGeneration)
        {
            StartCoroutine(CreateFigures());
        }
    }

    private IEnumerator CreateFigures()
    {
        _isGeneration = true;
        DestroyOldGameObject();
        if (_generatonSubStep == 4)
            AddDuplicateFigure();
        _generatonSubStep--;
        DevideFigures();
        AddFakeLines();
        InstantiateFigures();
        InstantiateLines();
        _isGeneration = false;
        if (_generatonSubStep == 0)
            _generatonSubStep = 4;
        yield return null;
    }

    private void DestroyOldGameObject()
    {
        var oldFigure = new Figure(GameData.Figures.First());
        Destroy(GameData.Figures.First().GameObject);
        GameData.InitializeData();
        GameData.Figures.Add(oldFigure);
    }

    private void AddDuplicateFigure()
    {
        var oldFigure = GameData.Figures.First();
        var newFigure = new Figure(oldFigure) { Position = GameData.GetNewPosition(oldFigure.Position) };
        GameData.Figures.Add(newFigure);
        GameData.Lines.Add(new Line(oldFigure.Name, newFigure.Name));
    }

    private void DevideFigures()
    {
        while (GameData.Figures.Any(f => !f.IsTriedToDevide))
        {
            foreach (var figure in GameData.Figures)
            {
                if (!figure.IsTriedToDevide)
                {
                    figure.IsTriedToDevide = true;
                    if (Random.Range(0, 5) >= _generatonSubStep && figure.Number >= 2)
                    {
                        figure.IsTriedToDevide = false;
                        figure.Number = figure.Number / 2;
                        var newFigure = new Figure(figure) { Position = GameData.GetNewPosition(figure.Position) };
                        if (newFigure.Position != Vector2.zero)
                        {
                            GameData.Figures.Add(newFigure);
                            GameData.Lines.Add(new Line(figure.Name, newFigure.Name));
                        }
                        else
                            figure.Number = figure.Number * 2;
                        break;
                    }
                }
            }
        }
    }

    private void AddFakeLines()
    {
        if (GameData.Figures.Count() > 2)
        {
            var fakesCount = GameData.Figures.Count() * 3;
            var stop = 1000;
            while (fakesCount > 0 && stop > 0)
            {
                stop--;
                var figureA = GameData.Figures[Random.Range(0, GameData.Figures.Count() - 1)];
                var figureB = GameData.Figures[Random.Range(0, GameData.Figures.Count() - 1)];
                if (figureA.Name != figureB.Name && !GameData.IsFiguresConnected(figureA.Name, figureB.Name)
                    && Vector2.Distance(figureA.Position, figureB.Position) < 3f)
                {
                    GameData.Lines.Add(new Line(figureA.Name, figureB.Name));
                    fakesCount--;
                }
            }
        }
    }

    private void InstantiateFigures()
    {
        foreach (var figure in GameData.Figures)
        {
            FigureGameObject.GetComponent<FigureNumberController>().Number = figure.Number;
            var createdGameObject = (GameObject)Instantiate(FigureGameObject, figure.Position, Quaternion.identity);
            createdGameObject.name = figure.Name;
            createdGameObject.transform.parent = ParentFigure.transform;
            figure.GameObject = createdGameObject;
        }
    }

    private void InstantiateLines()
    {
        foreach (var line in GameData.Lines)
        {
            var figuresA = GameData.Figures.Where(f => f.Name == line.FigureNameA).ToList();
            var figuresB = GameData.Figures.Where(f => f.Name == line.FigureNameB).ToList();
            if (figuresA.Any() && figuresB.Any())
            {
                var transformsA = figuresA.First().GameObject.GetComponent<FigureAnglesController>().Angles;
                var transformsB = figuresB.First().GameObject.GetComponent<FigureAnglesController>().Angles;
                var A = gameObject.transform;
                var B = gameObject.transform;
                float minDistance = 1000;
                foreach (var transformA in transformsA)
                    foreach (var transformB in transformsB)
                    {
                        var distance = Vector2.Distance(transformA.position, transformB.position);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            A = transformA;
                            B = transformB;
                        }
                    }
                var createdLine = (GameObject)Instantiate(LineGameObject, Vector2.zero, Quaternion.identity);

                var createdLineController = createdLine.GetComponent<LineController>();
                createdLineController.Transform1 = A;
                createdLineController.Transform2 = B;
            }
        }
    }
}
