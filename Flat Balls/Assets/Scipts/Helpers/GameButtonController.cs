using UnityEngine;

public class GameButtonController : MonoBehaviour
{
    private const string ButtonRestartTag = "ButtonRestart";
    private const string ButtonExitTag = "ButtonExit";
    private const string AllControllerTag = "All Controller";
    private AllController _allController;

    private bool _isPressed;

    void Start()
    {
        var allControllerGameObjet = GameObject.FindWithTag(AllControllerTag);
        if (allControllerGameObjet != null)
            _allController = allControllerGameObjet.GetComponent<AllController>();
    }
    void OnMouseDown()
    {
        _isPressed = true;
    }

    void OnMouseUp()
    {
        if (_isPressed && _allController != null)
        {
            if (CompareTag(ButtonRestartTag))
            {
                GameData.CurrentStatus = Status.Play;
                Application.LoadLevel(0);
            }
            else
            {
                if (CompareTag(ButtonExitTag))
                {
                    GameData.CurrentStatus = Status.Menu;
                    Application.LoadLevel(0);
                }
            }
        }
    }
}

