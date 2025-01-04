using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGun : MonoBehaviour, IWeapon
{
    public string WeaponName => "Balloon Gun";

    public void Use()
    {
        Debug.Log("Using Balloon Gun.");
    } 
    
}
