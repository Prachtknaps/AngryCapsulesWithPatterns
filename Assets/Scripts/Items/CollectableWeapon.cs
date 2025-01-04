using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IWeapon weapon = GetComponent<IWeapon>();
            if (weapon != null)
            {
                var player = other.GetComponent<PlayerController>();
                if (player != null)
                {
                    player.SetWeapon(weapon);
                    Debug.Log($"Deine Waffe ist nun: {weapon.WeaponName}");

                    Transform weaponHolder = other.transform.Find("Head/Weapon");
                    if (weaponHolder != null)
                    {
                        foreach (Transform child in weaponHolder)
                        {
                            Destroy(child.gameObject);
                        }

                        transform.SetParent(weaponHolder);
                        transform.localPosition = Vector3.zero;
                        transform.localRotation = Quaternion.identity;
                    }

                    Collider collider = GetComponent<Collider>();
                    if (collider != null)
                    {
                        collider.enabled = false;
                    }
                }
            }
        }
    }
}
