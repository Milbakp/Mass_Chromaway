using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Inventory inventory;
    public virtual void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }
    public virtual void ActivatePowerUp()
    {
        // This method will be overridden by specific power-up types
        Debug.Log("Power-up activated!");
    }
}
