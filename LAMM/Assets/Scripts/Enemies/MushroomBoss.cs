using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBoss : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject mushroomProjectilePrefab;

    private Animator myAnimator;
    private EnemyPathFinder enemyPathFinder;
    private FadeToRed fadeToRed;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        fadeToRed = GetComponent<FadeToRed>();
          
    }

    public void Attack()
    {
        
        myAnimator.SetTrigger(ATTACK_HASH);
        fadeToRed.changingColor = true;

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

    public void SpawnBossMushroomProjectileAnimEvent()
    {
        Instantiate(mushroomProjectilePrefab, transform.position, Quaternion.identity);
    }

}
