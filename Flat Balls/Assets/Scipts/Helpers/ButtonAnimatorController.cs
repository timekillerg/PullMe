using UnityEngine;

public class ButtonAnimatorController : MonoBehaviour
{
    private Animator _animator;
    private const string StartButtonTag = "Start";
    private const string AllControllerTag = "All Controller";
    private AllController _allController;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        var allControllerGameObjet = GameObject.FindWithTag(AllControllerTag);
        if (allControllerGameObjet != null)
            _allController = allControllerGameObjet.GetComponent<AllController>();
    }

    void OnMouseDown()
    {
        if (_animator != null)
            _animator.SetBool("isTouched", true);
    }

    void OnMouseUp()
    {
        if (_animator != null)
            _animator.SetBool("isTouched", false);
        if (CompareTag(StartButtonTag) && _allController != null)
            _allController.Game();
    }

}

