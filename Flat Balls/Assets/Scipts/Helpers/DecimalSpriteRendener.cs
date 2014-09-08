using UnityEngine;
using System.Collections;

public class DecimalSpriteRendener : MonoBehaviour
{
    public float ScaleX;
    public float ScaleY;
    public float Height;

    public GameObject DigitSpriteRenderer;
    public Sprite[] DigitSprites;

    private const string ChildTag = "DigitSprite";

    void Start()
    {
    }

    public void SetValue(int number)
    {
        CleanValue();
        var digits = number.ToString();
        for (int i = 0; i < digits.Length; i++)
        {
            int digit = -1;
            int.TryParse(digits[i].ToString(), out digit);
            if (digit >= 0)
            {
                var x = (i - digits.Length / 2) * Height;
                var position = gameObject.transform.position;
                position.x += x;

                var digitGameObject = (GameObject)Instantiate(DigitSpriteRenderer, position, Quaternion.identity);
                digitGameObject.transform.parent = gameObject.transform;

                if (ScaleX > 0)
                {
                    var scale = digitGameObject.transform.localScale;
                    scale.x = ScaleX;
                    digitGameObject.transform.localScale = scale;
                }
                if (ScaleY > 0)
                {
                    var scale = digitGameObject.transform.localScale;
                    scale.y = ScaleY;
                    digitGameObject.transform.localScale = scale;
                }
                var spriteRenderer = digitGameObject.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null && DigitSprites.Length > digit)
                {
                    spriteRenderer.sprite = DigitSprites[digit];
                }
            }
        }
    }

    public void CleanValue()
    {
        Transform[] allChildren = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.CompareTag(ChildTag))
                Destroy(child.gameObject);
        }
    }
}
