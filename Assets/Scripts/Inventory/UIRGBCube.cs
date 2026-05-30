using UnityEngine;
using UnityEngine.UI;

public class UIRGBCube : MonoBehaviour
{
    public Image targetImage; 
    public Sprite shatteredSprite, rainbowSprite;

    void Start()
    {
        targetImage = GetComponent<Image>();
    }

    public void setColor(string color)
    {
        switch (color)
        {
            case "Red":
                targetImage.color = Color.red;
                break;
            case "Green":
                targetImage.color = Color.green;
                break;
            case "Blue":
                targetImage.color = Color.blue;
                break;
            case "Rainbow":
                targetImage.color = Color.white;
                targetImage.sprite = rainbowSprite;
                break;
        }
    }

    public void shatterImage()
    {
        targetImage.sprite = shatteredSprite;
    }
}
