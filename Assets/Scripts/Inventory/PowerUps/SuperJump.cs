using UnityEngine;

public class SuperJump : PowerUp
{
    public Jump jumpScript;
    public SJIndicator sjIndicator;
    public override void Start()
    {
        base.Start();
        if (sjIndicator == null)
        {
            sjIndicator = FindAnyObjectByType<SJIndicator>();
        }
    }
    public override void ActivatePowerUp()
    {
        if(jumpScript == null)
        {
            jumpScript = FindAnyObjectByType<Jump>();
        }
        jumpScript.superJumpBool = true;
        jumpScript.superJumpForce = Random.Range(20f, 25f); // Set a random super jump force
        sjIndicator.superJumpIndicator.SetActive(true);
    }
}
