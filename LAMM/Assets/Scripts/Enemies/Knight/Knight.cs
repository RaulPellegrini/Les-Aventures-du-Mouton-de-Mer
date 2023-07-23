using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knight : MonoBehaviour, IEnemy
{
    [SerializeField] GameObject weaponCollider;
    private Animator myAnimator;
    private EnemyPathFinder enemyPathFinder;


    readonly int ATTACK_HASH = Animator.StringToHash("Attack");


    public void Awake()
    {
        myAnimator = GetComponent<Animator>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();

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

    private void WeaponColliderStart()
    {
        weaponCollider.SetActive(true);
    }

    private void WeaponColliderStop()
    {
        weaponCollider.SetActive(false);
    }

}

