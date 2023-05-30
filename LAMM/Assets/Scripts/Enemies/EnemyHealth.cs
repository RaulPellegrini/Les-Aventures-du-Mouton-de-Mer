using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackThurst = 15f;
    [SerializeField] private bool Chest = false;

    [SerializeField] bool knightBoss = false;

    //Check static

    private Animator myAnimator;

    public bool halfHealth = false;
    public bool quarterHealth = false;

    private int currentHealth;
    private Knockback knockback;
    private Flash flash;


    private void Awake()
    {
        knockback = GetComponent<Knockback>();
        flash = GetComponent<Flash>();
        myAnimator = GetComponent<Animator>();
 
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage) 
    { 
        currentHealth -= damage;
        if (currentHealth <= startingHealth*1/2) { halfHealth = true; }
        if (currentHealth <= startingHealth*1/4) { quarterHealth = true; }

        knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThurst);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (currentHealth <= 0 && !Chest) 
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            GetComponent<PickUpSpawner>().DropItems();
            Destroy(gameObject);

            if (knightBoss == true) { ActiveInventory.Instance.KnightBossInventory(); }


        }

        if (currentHealth <= 0 && Chest) { myAnimator.SetTrigger("Destroy");}
    
    }

#pragma warning disable IDE0051 // Remove unused private members
    private void Destroy()
#pragma warning restore IDE0051 // Remove unused private members
    {
        Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
        GetComponent<PickUpSpawner>().DropItems();
        Destroy(gameObject);
    }

}
