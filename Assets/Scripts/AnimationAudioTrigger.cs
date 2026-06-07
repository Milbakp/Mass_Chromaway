using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class AnimationAudioTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    public int soundEffectIndex, playSound; // Index to select which sound effect to play
    public List<AudioClip> soundEffects;


    void Start()
    {
        // Get the AudioSource component on this GameObject
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        // Check if the playSound flag is set to 1, which indicates that the sound should be played
        if (playSound == 1)
        {
            PlayAnimationSound();
            playSound = 0; // Reset the flag after playing the sound
        }
    }

    // This function will be called by the Animation Event
    public void PlayAnimationSound()
    {
        if (audioSource != null && soundEffectIndex >= 0 && soundEffectIndex < soundEffects.Count)
        {
            audioSource.PlayOneShot(soundEffects[soundEffectIndex]);
        }
    }
}
