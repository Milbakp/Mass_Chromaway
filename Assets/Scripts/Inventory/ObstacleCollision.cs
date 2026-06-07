using UnityEngine;
using System.Collections;

public class ObstacleCollision : MonoBehaviour
{
    private Inventory inventory;
    public bool hasShield = false;
    public GameObject shieldEffect; // Assign a shield effect prefab in the Inspector
    public AudioSource sfxAudio;
    public AudioClip smashClip;
    void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
        sfxAudio = GetComponent<AudioSource>();
        hasShield = false;
        shieldEffect.SetActive(false);
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
                shieldEffect.SetActive(false);
                StartCoroutine(deactiveShieldEffect(1f)); // Deactivate shield after 1 second, this is so the player passes through the obstacle before the shield deactivates
                Debug.Log("Shield absorbed the collision!");
            }
            sfxAudio.PlayOneShot(smashClip);
        }
    }

    IEnumerator deactiveShieldEffect(float duration)
    {
        yield return new WaitForSeconds(duration);
        hasShield = false;
    }
}
