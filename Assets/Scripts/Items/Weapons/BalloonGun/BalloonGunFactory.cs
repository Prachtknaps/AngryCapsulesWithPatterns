using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGunFactory : IWeaponFactory
{
    private readonly GameObject _balloonGunPrefab;

    public BalloonGunFactory(GameObject balloonGunPrefab)
    {
        _balloonGunPrefab = balloonGunPrefab;
    }

    public GameObject Create(Vector3 position, Quaternion rotation)
    {
        return Object.Instantiate(_balloonGunPrefab, position, rotation);
    }
}
