using UnityEngine;

public class BlackholeSize : MonoBehaviour
{
    private Inventory inventory;
    public Vector3 scale = new Vector3(0.01f, 0.01f, 0.01f);
    public float originalScale = 0.01f;
    public float increaseTotal = 0.01f;
    void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }
    void Update()
    {
        if(inventory.isGameOver)
        {
            float BigScale = 5 * originalScale;
            scale = new Vector3(BigScale, BigScale, BigScale);
            gameObject.transform.localScale = scale;
            return;
        }
        float newScale = (increaseTotal * inventory.currentCapacity.Count/inventory.maxCapacity) + originalScale;
        scale = new Vector3(newScale, newScale, newScale);
        gameObject.transform.localScale = scale;
    }
}
