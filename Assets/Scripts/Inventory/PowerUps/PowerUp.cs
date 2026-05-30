using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Inventory inventory;
    protected AudioManager audioManager;
    public virtual void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    public virtual void ActivatePowerUp()
    {
        // This method will be overridden by specific power-up types
        Debug.Log("Power-up activated!");
    }
    public virtual void SoundEffect()
    {
        Debug.Log("Played Sound Effect");
        // Do nothing
    }
}
