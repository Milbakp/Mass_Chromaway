using UnityEngine;
using System.Collections;

public class StartingAnimation : MonoBehaviour
{
    public Animator ladyAnimator, copAnimator;
    private GameManager gameManager;
    private Timer timer;
    public Rigidbody rb;
    public bool isGameOver = false;
    public Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ladyAnimator.Play("IntroLady");
        copAnimator.Play("IntroCop");
        gameManager = FindAnyObjectByType<GameManager>();
        timer = FindAnyObjectByType<Timer>();
        rb.isKinematic = true; // Make the rigidbody kinematic to prevent any physics interactions during the animation
        StartCoroutine(StartGameAfterAnimation());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator StartGameAfterAnimation()
    {
        yield return new WaitForSeconds(3f); 
        gameManager.startGame = true;
        timer.timerActive = true;
        ladyAnimator.enabled = false;
        copAnimator.enabled = false;
        rb.isKinematic = false; // Re-enable physics interactions after the animation is done
    }
    public IEnumerator GameOverAnimation()
    {
        rb.isKinematic = true;
        ladyAnimator.enabled = true;
        copAnimator.enabled = true;
        timer.timerActive = false;
        isGameOver = true;

        GameObject playerParent = Instantiate(new GameObject(), playerTransform.position, Quaternion.identity);
        playerTransform.SetParent(playerParent.transform);
        //playerParent.transform.localScale = Vector3.one; // Reset scale to 1,1

        ladyAnimator.Play("LadyLoss");
        copAnimator.Play("CopLoss");
        yield return new WaitForSeconds(4f);
        Time.timeScale = 0f;
        gameManager.gameOverScreen.SetActive(true); 
    }
}
