using UnityEngine;

public class RestartInitiator : MonoBehaviour
{
    private bool _isPressed;
    public GameObject FastGameController;

    void OnMouseDown()
    {
        _isPressed = true;
    }

    void OnMouseUp()
    {
        if (_isPressed)
        {
            Application.LoadLevel(0);
        }
    }
}

