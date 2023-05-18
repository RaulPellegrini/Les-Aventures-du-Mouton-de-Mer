using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskedWolf : MonoBehaviour, IEnemy
{

    [SerializeField] private GameObject mushroom;
    [SerializeField] private GameObject bag;
    
    private Animator myAnimator;
    private EnemyPathFinder enemyPathFinder;


    readonly int ATTACK_HASH = Animator.StringToHash("Attack");


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();

    }

    public void Attack()
    {
        myAnimator.SetTrigger(ATTACK_HASH);

    }

    private void MushorromSpawn()
    {
        Instantiate(mushroom, bag.transform.position, Quaternion.identity);

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
