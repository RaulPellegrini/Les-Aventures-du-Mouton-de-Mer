using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diabrete : MonoBehaviour, IEnemy
{
    [SerializeField] GameObject weaponCollider;
    [SerializeField] int attackCooldown;

    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private float heightY = 1.5f;
    [SerializeField] private float popDuration = 1f;
    [SerializeField] GameObject shadow;

    private Animator myAnimator;
    private EnemyPathFinder enemyPathFinder;
    private EnemyAI enemyAI;
    private Summoner summoner;
    private EnemyHealth enemyHealth;

    public bool canAttack = true;
    private bool summon = false;


    readonly int ATTACK_HASH = Animator.StringToHash("Attack");
    readonly int SUMMON_HASH = Animator.StringToHash("Summoning");


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        enemyAI = GetComponent<EnemyAI>();
        summoner = GetComponent<Summoner>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        StartCoroutine(AnimCurveSpawnRoutine());
    }

    private void Update()
    {
        if (enemyHealth.halfHealth)
        {
            myAnimator.SetTrigger(SUMMON_HASH);
        }
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

    private IEnumerator AnimCurveSpawnRoutine()
    {
        Vector2 startPoint = transform.position;
        float randomX = transform.position.x + Random.Range(-2f, 2f);
        float randomY = transform.position.y + Random.Range(-1f, 1f);

        Vector2 endPoint = new Vector2(randomX, randomY);

        float timePassed = 0f;

        while (timePassed < popDuration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / popDuration;
            float heightT = animCurve.Evaluate(linearT);
            float height = Mathf.Lerp(0f, heightY, heightT);

            transform.position = Vector2.Lerp(startPoint, endPoint, linearT) + new Vector2(0f, height);

            yield return null;
        }
    }

}
