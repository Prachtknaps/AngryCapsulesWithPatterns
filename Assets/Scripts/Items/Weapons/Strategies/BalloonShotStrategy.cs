using UnityEngine;

public class BalloonShotStrategy : IShootStrategy
{
    private float lastShootTime = 0.0f;
    private float cooldown = 0.5f;

    public void Shoot(IWeapon weapon)
    {
        if (Time.time - lastShootTime >= cooldown)
        {
            lastShootTime = Time.time;

            BalloonGun balloonGun = (BalloonGun) weapon;
            GameObject balloonSpawnPoint = balloonGun.GetBalloonSpawnPoint();
            GameObject balloon = balloonGun.GetBalloon();

            GameObject balloonInstance = Object.Instantiate(balloon, balloonSpawnPoint.transform.position, balloonSpawnPoint.transform.rotation);
            Balloon balloonScript = balloonInstance.GetComponent<Balloon>();
            if (balloonScript != null)
            {
                balloonScript.Initialize(weapon);
                balloonGun.PlaySound();
            }
        }
    }
}
