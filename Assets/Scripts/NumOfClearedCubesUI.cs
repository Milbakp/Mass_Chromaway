using UnityEngine;
using TMPro;

public class NumOfClearedCubesUI : MonoBehaviour
{
    public Inventory inventory;
    public TextMeshProUGUI numOfClearedCubesText;
    void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
        numOfClearedCubesText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        numOfClearedCubesText.text = "" + inventory.numOfDestroyedCubes;
    }
}
