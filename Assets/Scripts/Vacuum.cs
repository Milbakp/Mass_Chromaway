using UnityEngine;

public class Vacuum : MonoBehaviour
{
    public float pullSpeed = 5f;
    public string targetTag = "Item";
    private Inventory inventory;
    void Awake()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Vector3 targetPosition = transform.position;

            // Move the object toward the player
            other.transform.position = Vector3.MoveTowards(
                other.transform.position, 
                targetPosition, 
                pullSpeed * Time.deltaTime
            );

            // Snap and Destroy/Collect
            float distance = Vector3.Distance(other.transform.position, targetPosition);
            if (distance < 2f)
            {
                OnCollect(other.gameObject);
            }
        }
    }

    void OnCollect(GameObject obj)
    {
        // Add to inventory logic here
        //inventory.currentCapacity++;
        inventory.AddToCapacity(obj.GetComponent<RGBCube>().colorType);
        Debug.Log("Object Collected!");
        Destroy(obj); 
    }
}
