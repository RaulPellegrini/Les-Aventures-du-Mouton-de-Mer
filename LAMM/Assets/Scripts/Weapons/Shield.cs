using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;

    public void Attack()
    {
        Debug.Log("Shield");
   
    }

    public WeaponInfo GetWeaponInfo() { return weaponInfo; }

}

