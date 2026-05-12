using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    struct InventoryItem
    {
        public string color;
        public GameObject uiElement;
    }
    public int maxCapacity;
    public GameObject inventorySlotPrefab;
    public Transform inventorySlotParent;
    public List<string> currentCapacity = new List<string>();
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();
    private Dictionary<string, int> colorCounts = new Dictionary<string, int>();
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
        }
    }
    public void shatterCubes()
    {
        if(currentCapacity.Count == 0)
        {
            Debug.Log("No cubes to shatter!");
            return;
        }
        int rand = Random.Range(0, currentCapacity.Count);
        inventoryItems[rand].uiElement.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Shattered" + inventoryItems[rand].color;
        currentCapacity.Add(inventoryItems[rand].color);
        GameObject UIcube = Instantiate(inventorySlotPrefab, inventorySlotParent);
        UIcube.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Shattered" + inventoryItems[rand].color;
        inventoryItems.Add(new InventoryItem { color = inventoryItems[rand].color, uiElement = UIcube });
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
