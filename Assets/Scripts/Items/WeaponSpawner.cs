using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject balloonGunPrefab;
    public GameObject shrinkRayGunPrefab;
    public Transform[] spawnPoints;

    private List<IWeaponFactory> factories;

    void Start()
    {
        factories = new List<IWeaponFactory>()
        {
            new BalloonGunFactory(balloonGunPrefab),
            new ShrinkRayGunFactory(shrinkRayGunPrefab)
        };

        foreach (var spawnPoint in spawnPoints)
        {
            SpawnRandomWeapon(spawnPoint.position, spawnPoint.rotation);
        }
    }

    private void SpawnRandomWeapon(Vector3 position, Quaternion rotation)
    {
        int randomIndex = Random.Range(0, factories.Count);
        IWeaponFactory factory = factories[randomIndex];

        factory.Create(position, rotation);
    }
}
