using UnityEngine;

public class GameFieldScroller : MonoBehaviour
{
    public GameObject FiguresParent;
    private Vector2 _touchPosition;
    private Vector2 _endPosition;
    private Vector2 _startPosition;
    private Vector2 _finishPosition;
    private const float MinimalDistance = 0.3f;
    public float FigureMovingSpeed = 100f;

    void Start()
    {
        _touchPosition = Vector2.zero;
        _endPosition = Vector2.zero;
        _finishPosition = Vector2.zero;
        _startPosition = Vector2.zero;
    }

    void Update()
    {
        if (Vector2.Distance(FiguresParent.transform.position, _finishPosition) > MinimalDistance)
            FiguresParent.transform.position = Vector2.Lerp(FiguresParent.transform.position, _finishPosition, Time.deltaTime * FigureMovingSpeed);
    }

    void OnMouseDown()
    {
        GameData.CurrentStatus = Status.DragParent;
        var pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _touchPosition = pz;
        _startPosition = FiguresParent.transform.position;
    }

    void OnMouseDrag()
    {
        GameData.CurrentStatus = Status.DragParent;
        var pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _endPosition = pz;
        _finishPosition = _startPosition + _endPosition - _touchPosition;
    }

    void OnMouseUp()
    {
        GameData.CurrentStatus = Status.Play;
        var pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _endPosition = pz;
        _finishPosition = _startPosition + _endPosition - _touchPosition;
    }
}
