using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer myAudioMixer;

    [Header("UI Sliders")]
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    // Mixer parameter names (must match exactly what you exposed in Unity)
    private const string BGM_PARAMETER = "BGMVol";
    private const string SFX_PARAMETER = "SFXVol";

    private void Start()
    {
        // Set slider limits dynamically to avoid mistakes in the Inspector
        bgmSlider.minValue = 0.0001f; // Do not use 0, log10(0) is undefined/negative infinity
        bgmSlider.maxValue = 1f;
        sfxSlider.minValue = 0.0001f;
        sfxSlider.maxValue = 1f;

        myAudioMixer.SetFloat(BGM_PARAMETER, PlayerPrefs.GetFloat(BGM_PARAMETER, 0));
        myAudioMixer.SetFloat(SFX_PARAMETER, PlayerPrefs.GetFloat(SFX_PARAMETER, 0));

        // Load existing mixer values to position the sliders correctly on startup
        LoadSliderValue(BGM_PARAMETER, bgmSlider);
        LoadSliderValue(SFX_PARAMETER, sfxSlider);

        // Add listeners to detect when the player moves the sliders
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetBGMVolume(float sliderValue)
    {
        // Convert linear 0-1 slider value to decibels (-80dB to 20dB)
        float dbValue = Mathf.Log10(sliderValue) * 20;
        myAudioMixer.SetFloat(BGM_PARAMETER, dbValue);
        PlayerPrefs.SetFloat(BGM_PARAMETER, dbValue);
    }

    public void SetSFXVolume(float sliderValue)
    {
        float dbValue = Mathf.Log10(sliderValue) * 20;
        myAudioMixer.SetFloat(SFX_PARAMETER, dbValue);
        PlayerPrefs.SetFloat(SFX_PARAMETER, dbValue);
    }

    private void LoadSliderValue(string parameterName, Slider slider)
    {
        if (myAudioMixer.GetFloat(parameterName, out float mixerValue))
        {
            // Reverse math: Convert decibels back to a 0-1 linear value for the slider
            slider.value = Mathf.Pow(10, mixerValue / 20);
        }
        else
        {
            slider.value = 0.75f; // Default fallback if parameter isn't found
        }
    }
}