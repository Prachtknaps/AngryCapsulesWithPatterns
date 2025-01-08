using UnityEngine;

public interface IWeapon
{
    IShootStrategy ShootStrategy { get; set; }
    
    public void Shoot();
    public void OnShot(Collider collider);
    public void PlaySound();
}
