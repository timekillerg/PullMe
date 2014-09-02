using System;
using System.Collections.Generic;
using UnityEngine;

public class FiguresAndLinesCreator : MonoBehaviour
{
    public GameObject FigureGameObject;
    public GameObject LineGameObject;
    private Level _level;

    void Start()
    {
        _level = new Level();
        _level.InitializeLevel_1();
        GameData.Figures = _level.Figures;

        GameData.Lines = new List<Line>();
        GameData.CurrentStatus = Status.Play;
        CreateFigures();
        CreateLines();
    }

    private void CreateFigures()
    {
        foreach (var figure in GameData.Figures)
        {
            FigureGameObject.GetComponent<FigureNumberController>().Number = figure.Number;
            var createdFigure = Instantiate(FigureGameObject, figure.Position, Quaternion.identity);
            createdFigure.name = NewName();
            figure.Name = createdFigure.name;
            figure.GameObject = (GameObject)createdFigure;
        }
    }

    private string NewName()
    {
        return Guid.NewGuid().ToString();
    }

    private void CreateLines()
    {
        foreach (var line in _level.Lines)
        {
            if (GameData.Figures.Count > line.FigureIdA && GameData.Figures.Count > line.FigureIdB)
            {
                var transformsA = GameData.Figures[line.FigureIdA].GameObject.GetComponent<FigureAnglesController>().Angles;
                var transformsB = GameData.Figures[line.FigureIdB].GameObject.GetComponent<FigureAnglesController>().Angles;
                var a = gameObject.transform;
                var b = gameObject.transform;
                float minDistance = 1000;
                foreach(var transformA in transformsA)
                    foreach (var transformB in transformsB)
                    {
                        var distance = Vector2.Distance(transformA.position, transformB.position);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            a = transformA;
                            b = transformB;                            
                        }
                    }
                var createdLine = (GameObject)Instantiate(LineGameObject, Vector2.zero, Quaternion.identity);
                line.FigureNameA = GameData.Figures[line.FigureIdA].Name;
                line.FigureNameB = GameData.Figures[line.FigureIdB].Name;
                GameData.Lines.Add(line);
                var createdLineController = createdLine.GetComponent<LineController>();
                createdLineController.Transform1 = a;
                createdLineController.Transform2 = b;
            }
        }
    }
}