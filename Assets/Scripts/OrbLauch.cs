using UnityEngine;

public class OrbLauch : MonoBehaviour
{
    [Header("Settings")]
    public float minForce = 10f;
    public float maxForce = 15f;
    public float minAngle = 30f; // Degrees from floor
    public float maxAngle = 60f;
    //public float spread = 20f;   // Left/Right variance
    public float minSpread, maxSpread;

    void Start()
    {
        //Launch();
    }

    public void Launch()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Calculate a random upward angle (Pitch)
        float randomAngle = Random.Range(minAngle, maxAngle);
        
        // Calculate a random side-to-side spread (Yaw)
        // If the orb is on the right or left side of the platform it will lauch towards the platform.
        float randomSpread;
        if(transform.position.x > 0)
        {
            randomSpread = Random.Range(minSpread + 90, maxSpread); 
        }
        else
        {
            randomSpread = Random.Range(minSpread, maxSpread - 90); 
        }

        // Create the rotation based on the "Forward" direction
        Quaternion rotation = Quaternion.Euler(-randomAngle, randomSpread, 0);
        Vector3 direction = rotation * transform.forward;


        float force = Random.Range(minForce, maxForce);
        rb.AddForce(direction * force, ForceMode.Impulse);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Launch();
    }
}
