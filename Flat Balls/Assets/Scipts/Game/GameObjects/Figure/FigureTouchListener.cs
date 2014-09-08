using UnityEngine;

public class FigureTouchListener : MonoBehaviour
{
    private Vector2 _startPosition;
    private Vector2 _touchPosition;
    public float FigureMovingSpeed = 1f;
    private const float MinimalDistance = 0.01f;
    protected Animator Animator;

    void Start()
    {
        _startPosition = transform.position;
        _touchPosition = _startPosition;
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameData.CurrentStatus == Status.Play)
        {
            if (Vector2.Distance(_startPosition, _touchPosition) > MinimalDistance)
            {
                transform.position = Vector2.Lerp(transform.position, _touchPosition, Time.deltaTime * FigureMovingSpeed);
            }
            else if (Vector2.Distance(_startPosition, transform.position) > MinimalDistance)
            {
                transform.position = Vector2.Lerp(transform.position, _startPosition, Time.deltaTime * FigureMovingSpeed * 2);
            }
        }
        if (GameData.CurrentStatus == Status.DragParent)
        {
            _startPosition = transform.position;
            _touchPosition = _startPosition;
        }
    }

    void OnMouseDown()
    {   
        ChangeMousePositionAbsolute();
        Animator.SetBool("IsTouched", true);
    }

    void OnMouseDrag()
    {
        ChangeMousePositionAbsolute();
        Animator.SetBool("IsTouched", true);
    }

    void OnMouseUp()
    {
        _touchPosition = _startPosition;
        Animator.SetBool("IsTouched", false);
    }

    private void ChangeMousePositionAbsolute()
    {
        if (GameData.CurrentStatus == Status.Play)
        {
            var pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _touchPosition = pz;
        }
    }
}
