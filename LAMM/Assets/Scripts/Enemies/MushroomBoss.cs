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
    private Summoner summoner;

    private SummonLocation summonLocation;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");
    readonly int SUMMON_HASH = Animator.StringToHash("Summoning");

    public bool anxious = false;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        fadeToRed = GetComponent<FadeToRed>();
        summoner = GetComponent<Summoner>();
        summonLocation = GetComponentInChildren<SummonLocation>();

          
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
            summonLocation.summonFacingRight = true;
            


        }
        if (transform.position.x - PlayerController.Instance.transform.position.x > 0 && enemyPathFinder.facingRight == true)
        {
            enemyPathFinder.Flip();
            enemyPathFinder.facingRight = false;
            summonLocation.summonFacingRight = false;
        }

    }

    public void SpawnBossMushroomProjectileAnimEvent()
    {
        Instantiate(mushroomProjectilePrefab, transform.position, Quaternion.identity);
    }

    
    private void AnxietyDetection()
    {
        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) < anxietyDistance)
        {
            fadeToRed.ColorChangeToFinal();

            if (fadeToRed.colorFinal == true)
            {
                Summon();
                fadeToRed.colorFinal = false;
            }
        }

        else
        { 
            fadeToRed.ColorChangeToStart(); 
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
