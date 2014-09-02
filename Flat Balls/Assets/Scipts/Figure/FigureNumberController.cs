using System.Linq;
using UnityEngine;

public class FigureNumberController : MonoBehaviour
{
    public int Number = 1;
    public SpriteRenderer NumberSpriteRenderer;
    public Sprite[] AllNumbers;
    private const char TagSeparator = ' ';

    void Start()
    {
        while (Number > GetNumber())
            SwitchNextNumber();
    }

    public void SwitchNextNumber()
    {       
        SwitchNextSprite();
        SwitchNextTag();
    }

    private void SwitchNextSprite()
    {
        for (var i = 0; i < (AllNumbers.Length - 1); i++)
            if (NumberSpriteRenderer.sprite == AllNumbers[i])
            {
                NumberSpriteRenderer.sprite = AllNumbers[i + 1];
                break;
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
