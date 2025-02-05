using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diabrete : MonoBehaviour, IEnemy
{
    [SerializeField] GameObject weaponCollider;
    [SerializeField] int attackCooldown;

    [SerializeField] private float summonInternalCD = 20f;

    private Animator myAnimator;
    private EnemyPathFinder enemyPathFinder;
    private EnemyAI enemyAI;
    private Summoner summoner;

    public bool canAttack = true;
    public bool firstSummon = true;


    readonly int ATTACK_HASH = Animator.StringToHash("Attack");
    readonly int SUMMON_HASH = Animator.StringToHash("Summoning");


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        enemyAI = GetComponent<EnemyAI>();
        summoner = GetComponent<Summoner>();
    }

    private void Update()
    {

        Summon();

    }

    public void Attack()
    {

        if (canAttack && !summoner.isSummoning)
        {
            myAnimator.SetTrigger(ATTACK_HASH);
            canAttack = false;
            StartCoroutine(AttackCooldown());

        }

        SideCheck();

    }

    private void Caiting()
    {
        enemyAI.caiting = true;
    }

    private void SideCheck()
    {
        if (transform.position.x - PlayerController.Instance.transform.position.x < 0 && enemyPathFinder.facingRight == false)
        {
            enemyPathFinder.Flip();
            enemyPathFinder.facingRight = true;

        }

        if (transform.position.x - PlayerController.Instance.transform.position.x > 0 && enemyPathFinder.facingRight == true)
        {
            enemyPathFinder.Flip();
            enemyPathFinder.facingRight = false;

        }
    }

    private void Summon()
    {

        if (summoner.canSummon && !firstSummon)
        {
            myAnimator.SetTrigger(SUMMON_HASH);
            summoner.canSummon = false;
        }

        if (firstSummon)
        {
            StartCoroutine(SummonCooldown());
        }


    }

    private void WeaponColliderStart() 
    {
        weaponCollider.SetActive(true);
    }

    private void WeaponColliderStop()
    {
        weaponCollider.SetActive(false);
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
        enemyAI.caiting = false;
    }

    private IEnumerator SummonCooldown()
    {
        if(firstSummon)
        {
            firstSummon = false;
            yield return new WaitForSeconds(summonInternalCD);
            summoner.canSummon = true;

        }

    }

}
