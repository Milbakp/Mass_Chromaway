using UnityEngine;
using TMPro;

public class Scrambler : PowerUp
{
    private string[] colors = new string[] { "Red", "Green", "Blue" };
    public override void ActivatePowerUp()
    {
        //base.ActivatePowerUp();
        foreach (string color in colors)
        {
            inventory.colorCounts[color] = 0;
        }
        // Shuffle the colors in the inventory
        for (int i = 0; i < inventory.currentCapacity.Count; i++)
        {
            if(inventory.currentCapacity[i] == "Rainbow")
            {
                continue; // Skip scrambling Rainbow cubes
            }
            if(inventory.inventoryItems[i].isShattered)
            {
                inventory.colorCounts[inventory.inventoryItems[i].color]++;
                continue; // Skip scrambling shattered cubes
            }
            int randomIndex = Random.Range(0, colors.Length);
            inventory.currentCapacity[i] = colors[randomIndex];
            inventory.inventoryItems[i].color = colors[randomIndex];
            inventory.inventoryItems[i].uiElement.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = colors[randomIndex];
            inventory.inventoryItems[i].uiElement.transform.GetChild(1).GetComponent<UIRGBCube>().setColor(colors[randomIndex]);
            inventory.colorCounts[colors[randomIndex]]++;

            // Might want to look into a way to scramble the shatter cubes as well.
            // if(inventory.inventoryItems[i].isShattered)
            // {
            //     inventory.inventoryItems[i].uiElement.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Shattered" + colors[randomIndex];
            // }
            // else
            // {
            //     inventory.inventoryItems[i].uiElement.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = colors[randomIndex];
            // }
            
        }
        //inventory.colorCounts.Clear();
        Debug.Log("Inventory scrambled!");
    }

    public override void SoundEffect()
    {
        audioManager.playPowerUpClips(1);
    }
}
