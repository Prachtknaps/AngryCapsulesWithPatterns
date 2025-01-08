using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkRayGunFactory : IWeaponFactory
{
    private readonly GameObject _shrinkRayGunPrefab;

    public ShrinkRayGunFactory(GameObject shrinkRayGunPrefab)
    {
        _shrinkRayGunPrefab = shrinkRayGunPrefab;
    }

    public GameObject Create(Vector3 position, Quaternion rotation)
    {
        return Object.Instantiate(_shrinkRayGunPrefab, position, rotation);
    }
}
