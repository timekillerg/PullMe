using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    public GameObject BigAnimation1;
    public GameObject BigAnimation2;
    public GameObject BigAnimation3;

    private readonly Vector2 _bigAnimation1Position = new Vector3(-2.5f, 0.5f, 1f);
    private readonly Vector2 _bigAnimation2Position = new Vector3(0f, -5f, 1f);
    private readonly Vector2 _bigAnimation3Position = new Vector3(2.5f, 2.5f, 1f);

    void Start()
    {
        Instantiate(BigAnimation1, _bigAnimation1Position, Quaternion.identity);
        Instantiate(BigAnimation2, _bigAnimation2Position, Quaternion.identity);
        Instantiate(BigAnimation3, _bigAnimation3Position, Quaternion.identity);
    }
}
