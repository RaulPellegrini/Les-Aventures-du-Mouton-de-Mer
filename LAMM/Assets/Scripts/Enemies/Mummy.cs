using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy : MonoBehaviour, IEnemy
{
    private Animator myAnimator;
    private EnemyPathFinder enemyPathFinder;
    private Summoner summoner;

    private SummonLocation summonLocation;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");
    readonly int SUMMON_HASH = Animator.StringToHash("Summoning");

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        summoner = GetComponent<Summoner>();
        summonLocation = GetComponentInChildren<SummonLocation>();


    }

    public void Attack()
    {
        myAnimator.SetTrigger(ATTACK_HASH);

        if (transform.position.x - PlayerController.Instance.transform.position.x < 0 && enemyPathFinder.facingRight == false)
        {
            enemyPathFinder.Flip();
            enemyPathFinder.facingRight = true;
            summonLocation.summonFacingRight = true;



        }
        if (transform.position.x - PlayerController.Instance.transform.position.x > 0 && enemyPathFinder.facingRight == true)
        {
            enemyPathFinder.Flip();
            enemyPathFinder.facingRight = false;
            summonLocation.summonFacingRight = false;
        }

    }

    private void Summon()
    {
        if (summoner.canSummon)
        {
            myAnimator.SetTrigger(SUMMON_HASH);
            summoner.canSummon = false;
        }

    }
}
