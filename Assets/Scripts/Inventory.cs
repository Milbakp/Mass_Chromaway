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
        if (colorCounts["Red"] >= 3)
        {
            currentCapacity.RemoveAll(c => c == "Red");
            foreach (InventoryItem item in inventoryItems)
            {
                if (item.color == "Red")
                {
                    Destroy(item.uiElement);
                }
            }
            inventoryItems.RemoveAll(item => item.color == "Red");
            colorCounts["Red"] = 0;
            Debug.Log("Removed three red cubes!");
        }
        if (colorCounts["Green"] >= 3)
        {
            currentCapacity.RemoveAll(c => c == "Green");
            foreach (InventoryItem item in inventoryItems)
            {
                if (item.color == "Green")
                {
                    Destroy(item.uiElement);
                }
            }
            inventoryItems.RemoveAll(item => item.color == "Green");
            colorCounts["Green"] = 0;
            Debug.Log("Removed three green cubes!");
        }
        if (colorCounts["Blue"] >= 3)
        {
            currentCapacity.RemoveAll(c => c == "Blue");
            foreach (InventoryItem item in inventoryItems)
            {
                if (item.color == "Blue")
                {
                    Destroy(item.uiElement);
                }
            }
            inventoryItems.RemoveAll(item => item.color == "Blue");
            colorCounts["Blue"] = 0;
            Debug.Log("Removed three blue cubes!");
        }
    }
    public void shatterCubes()
    {
        int rand = Random.Range(0, currentCapacity.Count);
        InventoryItem cubeToShatter = inventoryItems[rand];
        AddToCapacity(cubeToShatter.color);
    }
}
