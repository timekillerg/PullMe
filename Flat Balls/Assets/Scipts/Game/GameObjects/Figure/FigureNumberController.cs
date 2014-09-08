using System.Linq;
using UnityEngine;

public class FigureNumberController : MonoBehaviour
{
    public int Number = 1;
    private const char TagSeparator = ' ';
    public GameObject DecimalRendererObject;

    void Start()
    {
        while (Number > GetNumber())
            SwitchNextTag();
        SetNumberSprite();
    }

    public void SwitchNextNumber()
    {
        SwitchNextTag();
        SetNumberSprite();
    }

    private void SetNumberSprite()
    {
        if (DecimalRendererObject != null)
        {
            var decimalRendererScript = DecimalRendererObject.GetComponent<DecimalSpriteRendener>();
            if (decimalRendererScript != null)
            {
                decimalRendererScript.SetValue(GetNumber());
            }
        }
    }

    private void SwitchNextTag()
    {
        var thisFigures = GameData.Figures.Where(f => f.Name == gameObject.name).ToList();
        if (thisFigures.Any())
            foreach (var figure in thisFigures)
                figure.Number = GetNumber() * 2;

        var words = tag.Split(TagSeparator);
        if (words.Any() && words.Length >= 2)
        {
            var word = words[0];
            var numder = int.Parse(words[1]);
            if (numder > 0) tag = word + TagSeparator + GetNumber() * 2;
        }
    }

    private int GetNumber()
    {
        var words = tag.Split(TagSeparator);
        return int.Parse(words[1]);
    }
}
