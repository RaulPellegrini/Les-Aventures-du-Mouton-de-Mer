using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : MonoBehaviour, IEnemy
{

    private Animator myAnimator;
    private EnemyPathFinder enemyPathFinder;
    private VampireSword vampireSword;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");


    public void Awake()
    {
        myAnimator = GetComponent<Animator>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        //vampireSword = GetComponentInChildren<VampireSword>();
        vampireSword = transform.GetChild(0).GetComponentInChildren<VampireSword>();
    }

    private void Update()
    {
        AimingCheck();
    }

    private void AimingCheck()
    {
        if (enemyPathFinder.facingRight == true)
        {
            vampireSword.aimingRight = true;
        }

        if (enemyPathFinder.facingRight == false)
        {
            vampireSword.aimingRight = false;
        }
    }

    public void Attack()
    {
        myAnimator.SetTrigger(ATTACK_HASH);

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

}
