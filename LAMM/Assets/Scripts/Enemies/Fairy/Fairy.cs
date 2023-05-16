using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    private Animator myAnimator;
    private EnemyPathFinder enemyPathFinder;
    private Shooter shooter;
    private FairyBow fairyBow;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        shooter = GetComponent<Shooter>();
        fairyBow = GetComponentInChildren<FairyBow>();

    }

    private void Update()
    {
        BowCheck();
    }

    private void Attack()
    {
        if (shooter.isShooting)
        {
            myAnimator.SetTrigger(ATTACK_HASH);
        }

    }

    private void BowCheck()
    {
        if (enemyPathFinder.facingRight == true)
        {
            fairyBow.AimingRight = true;
        }

        if (enemyPathFinder.facingRight == false)
        {
            fairyBow.AimingRight = false;
        }
    }

}
