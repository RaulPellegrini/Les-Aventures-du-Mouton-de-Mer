using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    private SpriteRenderer spriteRenderer;
    private Animator myAnimator;
    private PlayerHealth playerHealth;
    private Transform weaponCollider;


    readonly int ATTACK_HASH = Animator.StringToHash("Attack");

    //vampireSword = transform.GetChild(0).GetComponentsInChildren<VampireSword>();

    private void Awake()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();

    }

    private void Start()
    {
        weaponCollider = PlayerController.Instance.GetWeaponCollider();
    }

    public void Attack()
    {
        myAnimator.SetTrigger(ATTACK_HASH);
        weaponCollider.gameObject.SetActive(true);

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

    private void DefenseStart()
    {
        playerHealth.canTakeDamage = false;
    }

    private void DefenseeEnd()
    {
        playerHealth.canTakeDamage = true;
        weaponCollider.gameObject.SetActive(false);
    }

    public WeaponInfo GetWeaponInfo() { return weaponInfo; }

}

