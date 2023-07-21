using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IWeapon
{
    [SerializeField] GameObject shieldVFX;
    [SerializeField] private WeaponInfo weaponInfo;
    private SpriteRenderer spriteRenderer;
    private Animator myAnimator;
    private PlayerHealth playerHealth;
    private ActiveWeapon activeWeapon;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");
    readonly int STOP_HASH = Animator.StringToHash("StopAttack");
    readonly int DEFENDING_HASH = Animator.StringToHash("Defending");



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        activeWeapon = FindAnyObjectByType<ActiveWeapon>();
        myAnimator = GetComponent<Animator>();

    }

    private void Update()
    {
        SideDetection();
        DefendingStop();
    }

    public void Attack()
    {

        playerHealth.shielding = true;
        if (activeWeapon.attackButtonDown)
        {
            myAnimator.SetBool(DEFENDING_HASH, true);
            Instantiate(shieldVFX, transform.position, Quaternion.identity);
        }

    }

    private void SideDetection()
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

    private void DefendingStop()
    {
        if (!activeWeapon.attackButtonDown)
        {
            myAnimator.SetBool(DEFENDING_HASH, false);
            playerHealth.shielding = false;
        }
    }

    private void OnDestroy()
    {
        playerHealth.shielding = false;
    }

    public WeaponInfo GetWeaponInfo() { return weaponInfo; }

    private IEnumerator ShieldVFXRoutine()
    {
        yield return null;
    }

}

