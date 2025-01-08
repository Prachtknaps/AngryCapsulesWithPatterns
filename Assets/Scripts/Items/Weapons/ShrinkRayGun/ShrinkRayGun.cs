using UnityEngine;

public class ShrinkRayGun : MonoBehaviour, IWeapon
{
    public IShootStrategy ShootStrategy { get; set; }
    private AudioSource audioSource = null;

    private void Awake()
    {
        ShootStrategy = new ContinuousShotStrategy();
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
                enemy.ApplyDamage(10.0f);
                enemy.transform.localScale = enemy.transform.localScale * 0.95f;
                GameManager.Instance.GetScoreManager().AddPoints(10);
            }
        }
    }

    public void PlaySound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
