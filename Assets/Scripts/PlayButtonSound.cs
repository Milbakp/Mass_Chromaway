using UnityEngine;

public class PlayButtonSound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Static reference to the active instance
    public static PlayButtonSound Instance { get; private set; }
    private AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
        // If an instance already exists and it is not this one, destroy this duplicate
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return; // Exit early so no more code runs on this duplicate
        }

        // Set this object as the permanent instance
        Instance = this;
        
        // Prevent this object from being destroyed when loading new scenes
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound()
    {
        aud.Play();
    }
}
