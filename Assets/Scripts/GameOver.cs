using UnityEngine;
using TMPro;
public class GameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text timeText, cubeClearedText;
    public GameObject BestTime, BestCubeClear;
    private Inventory inventory;
    private Timer timer;
    void Awake()
    {
        inventory = FindAnyObjectByType<Inventory>();
        timer = FindAnyObjectByType<Timer>();
        cubeClearedText.text = inventory.numOfDestroyedCubes.ToString();
        timeText.text = timer.timerText.text;

        BestTime.SetActive(false);
        BestCubeClear.SetActive(false);
        if (timer.time > PlayerPrefs.GetFloat("TIMESCORE", 0f))
        {
            PlayerPrefs.SetFloat("TIMESCORE", timer.time);
            BestTime.SetActive(true);
        }
        if(inventory.numOfDestroyedCubes > PlayerPrefs.GetInt("CUBESCORE", 0))
        {
            PlayerPrefs.SetInt("CUBESCORE", inventory.numOfDestroyedCubes);
            BestCubeClear.SetActive(true);
        }

    }
}
