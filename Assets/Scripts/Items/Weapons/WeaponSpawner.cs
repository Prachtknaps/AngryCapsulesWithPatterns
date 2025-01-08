using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject balloonGunPrefab = null;
    [SerializeField] private GameObject shrinkRayGunPrefab = null;

    [Header("Spawn Points")]
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    
    private List<IWeaponFactory> factories;

    void Start()
    {
        factories = new List<IWeaponFactory>()
        {
            new BalloonGunFactory(balloonGunPrefab),
            new ShrinkRayGunFactory(shrinkRayGunPrefab)
        };
    }

    public void SpawnWeapons()
    {
        foreach (Transform spawnPoint in spawnPoints)
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
