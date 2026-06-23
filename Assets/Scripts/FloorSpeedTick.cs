using UnityEngine;
using System.Collections;
public class FloorSpeedTick : MonoBehaviour
{
    public GameManager gameManager;
    public float tickInterval = 1f; // Time in seconds between each tick
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        StartCoroutine(waitForSecondsCoroutine(10f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator FloorSpeedTickCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            gameManager.floorSpeed += tickInterval;
        }
    }
    IEnumerator waitForSecondsCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (PlayerPrefs.GetInt("STELLARMODE", 0) == 1)
        {
            StartCoroutine(FloorSpeedTickCoroutine());
            Debug.Log("Floor speed tick started");
        }
    }
}
