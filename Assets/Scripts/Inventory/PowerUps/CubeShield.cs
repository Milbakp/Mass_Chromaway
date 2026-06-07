using UnityEngine;

public class CubeShield : PowerUp
{
    ObstacleCollision obstacleCollision;
    public override void Start()
    {
        base.Start();
        obstacleCollision = FindAnyObjectByType<ObstacleCollision>();
    }

    public override void ActivatePowerUp()
    {
        obstacleCollision.hasShield = true;
        obstacleCollision.shieldEffect.SetActive(true);
        Debug.Log("Cube Shield Activated! You are now protected from the next obstacle collision.");
    }
    public override void SoundEffect()
    {
        audioManager.playPowerUpClips(2);
    }
}
