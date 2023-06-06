using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBoss : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject mushroomProjectilePrefab;
    [SerializeField] private int anxietyDistance = 5;

    private Animator myAnimator;
    private EnemyPathFinder enemyPathFinder;
    private FadeToRed fadeToRed;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");
    readonly int SUMMON_HASH = Animator.StringToHash("Summoning");

    public bool anxious = false;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        fadeToRed = GetComponent<FadeToRed>();
          
    }

    private void Update()
    {
        AnxietyDetection();
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

    public void SpawnBossMushroomProjectileAnimEvent()
    {
        Instantiate(mushroomProjectilePrefab, transform.position, Quaternion.identity);
    }

    
    private void AnxietyDetection()
    {
        //if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) < anxietyDistance)
        
        if (anxious)
        {
            fadeToRed.ColorChangeToFinal();

            if (fadeToRed.colorFinal == true)
            {
                Summon();
            }
        }

        else if (!anxious)
        { 
            fadeToRed.ColorChangeToStart(); 
        }
    }
    
    private void Summon()
    {
        myAnimator.SetTrigger(SUMMON_HASH);
    }

}
