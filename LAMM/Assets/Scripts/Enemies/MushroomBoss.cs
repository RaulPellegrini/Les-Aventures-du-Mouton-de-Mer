using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBoss : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject mushroomProjectilePrefab;
    [SerializeField] private float colorChangeSpeed = 1f;
    [SerializeField] private GameObject enragedMushroom;

    private Animator myAnimator;
    private SpriteRenderer spriteRenderer;
    private EnemyPathFinder enemyPathFinder;
    private FadeToRed fadeToRed;

    //private IEnumerator colorRoutine;


    readonly int ATTACK_HASH = Animator.StringToHash("Attack");

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        fadeToRed = GetComponent<FadeToRed>();

          
    }
    public void Attack()
    {

        // Quando atacar, ficar vermelho 
        //fadeToRed.fadeToRed();
        //spriteRenderer.color = Color.red;


        //float alpha = Mathf.MoveTowards(spriteRenderer.color.a, targetAlpha, fadeSpeed * Time.deltaTime);

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

    public void SpawnBossMushroomProjectileAnimEvent()
    {
        Instantiate(mushroomProjectilePrefab, transform.position, Quaternion.identity);
    }

}
