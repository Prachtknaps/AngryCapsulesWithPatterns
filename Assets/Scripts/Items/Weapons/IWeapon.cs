using UnityEngine;

public interface IWeapon
{
    string WeaponName { get; }
    IShootStrategy ShootStrategy { get; set; }
    
    public abstract void Shoot();
    public abstract void OnShot(Collider collider);
}
