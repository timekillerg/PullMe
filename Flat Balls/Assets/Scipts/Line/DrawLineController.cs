using UnityEngine;

public class DrawLineController : MonoBehaviour
{
    void OnMouseDown()
    {
        if (GameData.CurrentStatus == Status.DrawLine)
        {
            if (NewLineData.NewLineFigureA == null)
                NewLineData.NewLineFigureA = gameObject;
            else if (NewLineData.NewLineFigureA != gameObject &&
                NewLineData.NewLineFigureB == null &&
                !GameData.IsFiguresConnected(NewLineData.NewLineFigureA.name, gameObject.name))
                NewLineData.NewLineFigureB = gameObject;
        }
    }
}