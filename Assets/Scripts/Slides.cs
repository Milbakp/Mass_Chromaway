using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class Slides : MonoBehaviour
{
    public List<GameObject> slides = new List<GameObject>();
    public GameObject previousButton, nextButton;
    public int currentSlide;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSlide = 0;
    }
    void Update()
    {
        if(currentSlide == 0)
        {
            previousButton.SetActive(false);
        }
        else{
            previousButton.SetActive(true);
        }
        if(currentSlide == slides.Count - 1)
        {
            nextButton.SetActive(false);
        }
        else{
            nextButton.SetActive(true);
        }

    }

    public void nextSlide()
    {
        slides[currentSlide].SetActive(false);
        currentSlide += 1;
        slides[currentSlide].SetActive(true);
        PlayButtonSound.Instance.PlaySound();
    }
    public void previousSlide()
    {
        slides[currentSlide].SetActive(false);
        currentSlide -= 1;
        slides[currentSlide].SetActive(true);
        PlayButtonSound.Instance.PlaySound();
    }
    public void menu()
    {
        SceneManager.LoadScene("MenuScene");
        PlayButtonSound.Instance.PlaySound();
    }
}
