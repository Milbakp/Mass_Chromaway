using UnityEngine;

public class Shatter_Clear : PowerUp
{
    private string[] colors = new string[] { "Red", "Green", "Blue", "Rainbow" };
    public override void ActivatePowerUp()
    {
        foreach (string color in colors)
        {
            if(inventory.colorCounts[color] == 2)
            {
                inventory.removeOneColour(color);
            }
            else if (inventory.colorCounts[color] == 1)
            {
                inventory.shatterCubes(color);
            }
        }
        // for (int i = 0; i < inventory.currentCapacity.Count; i++)
        // {
        //     if(inventory.currentCapacity[i] == "Rainbow")
        //     {
        //         continue; // Skip scrambling Rainbow cubes
        //     }
        //     int randomIndex = Random.Range(0, colors.Length);
        //     inventory.currentCapacity[i] = colors[randomIndex];
        //     inventory.inventoryItems[i].color = colors[randomIndex];
        //     inventory.inventoryItems[i].uiElement.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = colors[randomIndex];
        //     inventory.colorCounts[colors[randomIndex]]++;
        // }
    }

    public override void SoundEffect()
    {
        audioManager.playPowerUpClips(0);
    }
}
