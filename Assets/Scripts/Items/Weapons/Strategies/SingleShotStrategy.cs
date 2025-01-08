using UnityEngine;

public class SingleShotStrategy : IShootStrategy
{
    private float lastShootTime = 0.0f;
    private float cooldown = 1.0f;
    
    public void Shoot(IWeapon weapon)
    {
        if (Time.time - lastShootTime >= cooldown)
        {
            lastShootTime = Time.time;

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
