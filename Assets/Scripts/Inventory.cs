using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxCapacity;
    public GameObject inventorySlotPrefab;
    public Transform inventorySlotParent;
    public List<string> currentCapacity = new List<string>();
    void Start()
    {
        currentCapacity.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCapacity.Count >= maxCapacity)
        {
            Debug.Log("Inventory is full!");
        }
    }

    public void AddToCapacity(string color)
    {
        GameObject UIcube = Instantiate(inventorySlotPrefab, inventorySlotParent);
        UIcube.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = color;
    }
}
