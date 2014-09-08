using UnityEngine;

public class OuputScores : MonoBehaviour
{
    public DecimalSpriteRendener decimalSpriteRenderer;
    private int _currentScore;

    void Start()
    {
        _currentScore = GameData.Scores;
    }

    void Update()
    {
        if (_currentScore != GameData.Scores)
        {
            _currentScore = GameData.Scores;
            decimalSpriteRenderer.SetValue(_currentScore);
        }
    }
}