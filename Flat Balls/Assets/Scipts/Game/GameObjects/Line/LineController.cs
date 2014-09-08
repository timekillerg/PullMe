using UnityEngine;

public class LineController : MonoBehaviour
{
    public Transform Transform1;
    public Transform Transform2;
    private LineRenderer _lineRenderer;

    public void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.SetPosition(0, Transform1.position);
        _lineRenderer.SetPosition(1, Transform2.position);
    }

    void Update()
    {
        if (Transform1 != null)
            _lineRenderer.SetPosition(0, Transform1.position);
        if (Transform2 != null)
            _lineRenderer.SetPosition(1, Transform2.position);
        if (Transform1 == null || Transform2 == null)
            Destroy(gameObject);
    }
}
