using UnityEngine;

public class BalloonGunFactory : IWeaponFactory
{
    private readonly GameObject balloonGunPrefab;

    public BalloonGunFactory(GameObject balloonGunPrefab)
    {
        this.balloonGunPrefab = balloonGunPrefab;
    }

    public GameObject Create(Vector3 position, Quaternion rotation)
    {
        return Object.Instantiate(balloonGunPrefab, position, rotation);
    }
}
