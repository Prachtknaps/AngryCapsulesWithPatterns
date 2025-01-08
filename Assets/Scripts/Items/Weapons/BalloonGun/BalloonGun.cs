using UnityEngine;

public class BalloonGun : MonoBehaviour, IWeapon
{
    public IShootStrategy ShootStrategy { get; set; }
    [SerializeField] private GameObject balloonSpawnPoint;
    [SerializeField] private GameObject balloon;
    private AudioSource audioSource = null;

    private void Awake()
    {
        ShootStrategy = new BalloonShotStrategy();
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        ShootStrategy?.Shoot(this);
    }

    public void OnShot(Collider collider)
    {
        if (collider != null)
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.ApplyDamage(20.0f);
                GameManager.Instance.GetScoreManager().AddPoints(20);
            }
        }
    }

    public GameObject GetBalloonSpawnPoint()
    {
        return balloonSpawnPoint;
    }

    public GameObject GetBalloon()
    {
        return balloon;
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}
