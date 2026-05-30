using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private AudioSource bgm, sfx;
    private AudioMixer master;
    public List<AudioClip> powerUpClips = new List<AudioClip>();
    void Start()
    {
        bgm = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
        sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playPowerUpClips(int numClip)
    {
        sfx.PlayOneShot(powerUpClips[numClip]);
    }
}
