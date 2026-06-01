using UnityEngine;
using TMPro;

public class CapacityTextUpdate : MonoBehaviour
{
    private Inventory inventory;
    public TMP_Text capacityText;
    void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        capacityText.text = $"{inventory.maxCapacity}/{inventory.currentCapacity.Count}";
    }
}
