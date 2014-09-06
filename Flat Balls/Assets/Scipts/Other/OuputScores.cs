using UnityEngine;

public class OuputScores : MonoBehaviour
{
    void Update()
    {
        guiText.text = GameData.Scores.ToString("D");
    }
}