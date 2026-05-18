using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private Inventory inventory;
    public bool hasShield = false;
    public GameObject shieldEffect; // Assign a shield effect prefab in the Inspector
    void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
        hasShield = false;
        shieldEffect.SetActive(false);
    }
    void Update()
    {
        if (hasShield && !shieldEffect.activeInHierarchy)
        {
            shieldEffect.SetActive(true);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.collider.gameObject.CompareTag("Obstacle"))
        {
            //Debug.Log("Collided with obstacle!");
            if (!hasShield)
            {
                inventory.shatterCubes();
            }
            else
            {
                hasShield = false;
                shieldEffect.SetActive(false);
                Debug.Log("Shield absorbed the collision!");
            }
        }
    }
}
