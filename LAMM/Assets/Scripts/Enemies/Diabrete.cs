using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diabrete : MonoBehaviour, IEnemy
{
    [SerializeField] GameObject weaponCollider;
    [SerializeField] int attackCooldown;

    private Animator myAnimator;
    private EnemyPathFinder enemyPathFinder;
    private EnemyAI enemyAI;

    public bool canAttack = true;


    readonly int ATTACK_HASH = Animator.StringToHash("Attack");


    public void Awake()
    {
        myAnimator = GetComponent<Animator>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        enemyAI = GetComponent<EnemyAI>();
    }

    public void Attack()
    {
        if (canAttack)
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

            canAttack = false;
            enemyAI.caiting = true;
            StartCoroutine(AttackCooldown());

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

}
