using UnityEngine;

public interface IWeaponFactory
{
    public GameObject Create(Vector3 position, Quaternion rotation);
}
