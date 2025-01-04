using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkRayGun : MonoBehaviour, IWeapon
{
    public string WeaponName => "Shrink Ray Gun";

    public void Use()
    {
        Debug.Log("Using Shrink Ray Gun");
    }
}
