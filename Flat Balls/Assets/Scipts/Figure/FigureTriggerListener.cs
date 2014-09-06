using System.Linq;
using UnityEngine;

public class FigureTriggerListener : MonoBehaviour
{
    private FigureNumberController _otherNumberController;
    private GameObject _other;
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
            _other = other.gameObject;
            AnimateTriggeredObject();
            _isTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _isTriggered = false;
        AnimateTriggeredObject();
        _otherNumberController = null;
    }

    private void AnimateTriggeredObject()
    {
        if (_other != null)
        {
            var animator = _other.GetComponent<Animator>();
            if (animator != null)
                animator.SetBool("IsTriggered", _isTriggered);
        }
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
        AnimateTriggeredObject();
        _otherNumberController = null;
    }

    private void DestroyFigure()
    {
        var figures = GameData.Figures.Where(f => f.Name == name).ToList();
        if (figures.Any())
        {
            GameData.Scores += figures.First().Number;
            GameData.Figures.Remove(figures.First());
        }
        Destroy(gameObject);
    }
}
