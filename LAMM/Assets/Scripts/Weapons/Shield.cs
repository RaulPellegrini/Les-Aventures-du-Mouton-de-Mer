using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Attack()
    {
        Debug.Log("Shield");
   
    }

    private void Update()
    {
        if (transform.eulerAngles.z is > 90 and < 270)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;

        }
    }

    public WeaponInfo GetWeaponInfo() { return weaponInfo; }

}

