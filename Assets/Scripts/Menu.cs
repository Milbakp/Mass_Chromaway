using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject menu, settings;
    public TMP_Text timeText, cubeClearedText;
    public Toggle stellarMode; 
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

        stellarMode.isOn = PlayerPrefs.GetInt("STELLARMODE", 0) == 1 ? true : false;

        playButtonSound = FindAnyObjectByType<PlayButtonSound>();

    }

    // Update is called once per frame
    void Update()
    {
        // Remove this code in release builds, it's just for testing purposes to clear PlayerPrefs when Ctrl + R is pressed.
        if(Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftControl))
        {
            resetPlayerPrefs();
        }
    }
    private void resetPlayerPrefs()
    {
        //#if UNITY_EDITOR
            // This line only exists in the Unity Editor
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("PlayerPrefs have been cleared.");
        //#endif
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
    public void toggleStellarMode()
    {
        PlayerPrefs.SetInt("STELLARMODE", stellarMode.isOn ? 1 : 0);
        playButtonSound.PlaySound();
    }
    public void quit()
    {
        Application.Quit();
    }

}
