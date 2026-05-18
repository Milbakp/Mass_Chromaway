using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // structs are kind of troublesome, but Ill keep it here for now.
    public class InventoryItem
    {
        public string color;
        public GameObject uiElement;
        public bool isShattered = false;
    }
    public int maxCapacity;
    public GameObject inventorySlotPrefab;
    public Transform inventorySlotParent;
    public List<string> currentCapacity = new List<string>();
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public Dictionary<string, int> colorCounts = new Dictionary<string, int>();
    public bool isGameOver = false;
    private string[] colors = new string[] { "Red", "Green", "Blue" };
    void Start()
    {
        currentCapacity.Clear();
        colorCounts.Clear();
        foreach (InventoryItem item in inventoryItems)
        {
            Destroy(item.uiElement);
        }
        inventoryItems.Clear();
        colorCounts["Red"] = 0;
        colorCounts["Green"] = 0;
        colorCounts["Blue"] = 0;
        colorCounts["Rainbow"] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForThrees();
        if (currentCapacity.Count >= maxCapacity && !isGameOver)
        {
            Debug.Log("Inventory is full!");
            isGameOver = true;
        }
    }

    public void AddToCapacity(string color)
    {
        currentCapacity.Add(color);
        GameObject UIcube = Instantiate(inventorySlotPrefab, inventorySlotParent);
        UIcube.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = color;
        inventoryItems.Add(new InventoryItem { color = color, uiElement = UIcube });
        colorCounts[color] = colorCounts.GetValueOrDefault(color, 0) + 1;
    }

    public void CheckForThrees()
    {
        foreach (string color in colors)
        {
            if (colorCounts[color] >= 3)
            {
                removeOneColour(color);
            }
            else if(colorCounts[color] + colorCounts["Rainbow"] >= 3) // Rainbow cubes can substitute for any color, so we check if the count of the color plus the count of Rainbow cubes is at least 3
            {
                removeOneColour("Rainbow");
                removeOneColour(color);
                Debug.Log($"Removed three {color} cubes with a Rainbow cube!");
            }
        }
    }
    public void shatterCubes()
    {
        if(currentCapacity.Count == 0)
        {
            Debug.Log("No cubes to shatter!");
            return;
        }
        // Randomly select a cube to shatter
        int rand = Random.Range(0, currentCapacity.Count);
        if(inventoryItems[rand].isShattered)
        {
            Debug.Log("Cube is already shattered!");
            for(int i = 0; i < inventoryItems.Count; i++)
            {
                if(!inventoryItems[i].isShattered)
                {
                    rand = i;
                    break;
                }
            }
        }
        if(inventoryItems[rand].isShattered)
        {
            Debug.Log("All cubes are shattered!");
            return;
        }

        inventoryItems[rand].uiElement.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Shattered" + inventoryItems[rand].color;
        inventoryItems[rand].isShattered = true;
        currentCapacity.Add(inventoryItems[rand].color);
        GameObject UIcube = Instantiate(inventorySlotPrefab, inventorySlotParent);
        UIcube.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Shattered" + inventoryItems[rand].color;
        inventoryItems.Add(new InventoryItem { color = inventoryItems[rand].color, uiElement = UIcube, isShattered = true });
    }

    public void shatterCubes(string color)
    {
        if(currentCapacity.Count == 0)
        {
            Debug.Log("No cubes to shatter!");
            return;
        }
        // Randomly select a cube to shatter
        for(int i = 0; i < inventoryItems.Count; i++)
        {
            if(inventoryItems[i].color == color && !inventoryItems[i].isShattered)
            {
                inventoryItems[i].uiElement.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Shattered" + inventoryItems[i].color;
                inventoryItems[i].isShattered = true;
                currentCapacity.Add(inventoryItems[i].color);
                GameObject UIcube = Instantiate(inventorySlotPrefab, inventorySlotParent);
                UIcube.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Shattered" + inventoryItems[i].color;
                inventoryItems.Add(new InventoryItem { color = inventoryItems[i].color, uiElement = UIcube, isShattered = true });
                return;
            }
        }
    }

    public void removeOneColourFlip()
    {
        if(currentCapacity.Count == 0)
        {
            Debug.Log("No cubes to remove!");
            return;
        }
        int rand = Random.Range(0, currentCapacity.Count);
        string color = inventoryItems[rand].color;
        removeOneColour(color);
    }

    public void removeOneColour(string color)
    {
        currentCapacity.RemoveAll(c => c == color);
        foreach (InventoryItem item in inventoryItems)
        {
            if (item.color == color)
            {
                Destroy(item.uiElement);
            }
        }
        inventoryItems.RemoveAll(item => item.color == color);
        colorCounts[color] = 0;
        Debug.Log($"Removed three {color} cubes!");
    }
}
