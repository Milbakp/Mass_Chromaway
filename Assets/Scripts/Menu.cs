using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject menu, settings;
    public TMP_Text timeText, cubeClearedText;
    private PlayButtonSound playButtonSound;
    void Start()
    {
        menu.SetActive(true);
        settings.SetActive(false);

        TimeSpan timeSpan = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("TIMESCORE", 0));
        int minutes = timeSpan.Minutes;
        int seconds = timeSpan.Seconds;
        timeText.text =  minutes.ToString() + ":" + seconds.ToString("D2");

        cubeClearedText.text = PlayerPrefs.GetInt("CUBESCORE", 0).ToString();

        playButtonSound = FindAnyObjectByType<PlayButtonSound>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame()
    {
        SceneManager.LoadScene("EndlessRunner");
        playButtonSound.PlaySound();
    }
    public void toggleMenu()
    {
        menu.SetActive(!menu.activeInHierarchy);
        settings.SetActive(!settings.activeInHierarchy);
        playButtonSound.PlaySound();
    }
    public void quit()
    {
        Application.Quit();
    }

}
