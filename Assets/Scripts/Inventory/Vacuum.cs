using UnityEngine;

public class Vacuum : MonoBehaviour
{
    public float pullSpeed = 5f;
    public string targetTag = "Item";
    public string targetTag2 = "PowerUp";
    private Inventory inventory;
    private AudioSource sfxAudio;
    public AudioClip sfxClip;
    void Awake()
    {
        inventory = FindAnyObjectByType<Inventory>();
        sfxAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(targetTag) || other.CompareTag(targetTag2))
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
        if (obj.CompareTag(targetTag2))
        {
            PowerUp powerUp = obj.GetComponent<PowerUp>();
            if (powerUp != null)
            {
                powerUp.ActivatePowerUp();
                powerUp.SoundEffect();
            }
            Destroy(obj);
            return;
        }
        sfxAudio.PlayOneShot(sfxClip);
        inventory.AddToCapacity(obj.GetComponent<RGBCube>().colorType);
        //Debug.Log("Object Collected!");
        Destroy(obj); 
    }
}
