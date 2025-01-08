using UnityEngine;

public class ContinuousShotStrategy : IShootStrategy
{
    private float lastShootTime = 0.0f;
    private float interval = 0.25f;

    public void Shoot(IWeapon weapon)
    {
        if (Time.time - lastShootTime >= interval)
        {
            lastShootTime = Time.time;
            weapon.PlaySound();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100.0f))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    weapon.OnShot(hit.collider);
                }
            }
        }
    }
}
