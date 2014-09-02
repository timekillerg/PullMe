using UnityEngine;

public class DrawLineInitiator : MonoBehaviour
{
    private bool _isPressed;
    public GameObject LineGameObject;

    void OnMouseDown()
    {
        _isPressed = true;
    }

    void OnMouseUp()
    {
        if (_isPressed)
        {
            GameData.CurrentStatus = Status.DrawLine;
            _isPressed = false;
        }
    }

    void Update()
    {
        if (GameData.CurrentStatus == Status.DrawLine && NewLineData.NewLineFigureA != null && NewLineData.NewLineFigureB != null)
        {
            var transformsA = NewLineData.NewLineFigureA.GetComponent<FigureAnglesController>().Angles;
            var transformsB = NewLineData.NewLineFigureB.GetComponent<FigureAnglesController>().Angles;
            var a = gameObject.transform;
            var b = gameObject.transform;
            float minDistance = 1000;
            foreach (var transformA in transformsA)
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
            var line = new Line(0,0)
            {
                FigureNameA = NewLineData.NewLineFigureA.name,
                FigureNameB = NewLineData.NewLineFigureB.name
            };
            GameData.Lines.Add(line);
            var createdLineController = createdLine.GetComponent<LineController>();
            createdLineController.Transform1 = a;
            createdLineController.Transform2 = b;
            GameData.CurrentStatus = Status.Play;
            NewLineData.NewLineFigureA = null;
            NewLineData.NewLineFigureB = null;
        }
    }
}
