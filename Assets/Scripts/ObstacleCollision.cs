using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private Inventory inventory;
    void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.collider.gameObject.CompareTag("Obstacle"))
        {
            //Debug.Log("Collided with obstacle!");
            inventory.shatterCubes();
        }
    }
}
