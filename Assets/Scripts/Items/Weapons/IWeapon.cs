using UnityEngine;

public interface IWeapon
{
    IShootStrategy ShootStrategy { get; set; }
    
    public abstract void Shoot();
    public abstract void OnShot(Collider collider);
}
