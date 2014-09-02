using System.Linq;
using UnityEngine;

public class FigureTriggerListener : MonoBehaviour
{
    private FigureNumberController _otherNumberController;
    private bool _isTriggered;
    private bool _isTouched;

    void Start()
    {
        _isTriggered = false;
        _isTouched = false;
    }

    void OnMouseDown()
    {
        _isTouched = true;
        _isTriggered = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (_isTouched && other.tag.StartsWith("Figure"))
        {
            _otherNumberController = other.gameObject.GetComponent<FigureNumberController>();
            _isTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _otherNumberController = null;
        _isTriggered = false;
    }

    void OnMouseUp()
    {
        if (_isTriggered && _isTouched && _otherNumberController != null && _otherNumberController.CompareTag(tag)
            && GameData.IsFiguresConnected(_otherNumberController.name, gameObject.name))
        {
            _otherNumberController.SwitchNextNumber();
            DestroyFigure();
        }
        _isTouched = false;
        _isTriggered = false;
        _otherNumberController = null;
    }

    private void DestroyFigure()
    {
        var figures = GameData.Figures.Where(f => f.Name == name).ToList();
        if (figures.Any())
            GameData.Figures.Remove(figures.First());
        Destroy(gameObject);
    }
}
