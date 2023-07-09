using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBoss : MonoBehaviour, IEnemy
{
    private Animator myAnimator;
    private EnemyPathFinder enemyPathFinder;
    private SummonLocation summonLocation;
    private EnemyHealth enemyHealth;
    private Summoner summoner;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");
    readonly int ATTACKANIMSTOP_HASH = Animator.StringToHash("StopAttackAnim");
    readonly int SUMMON_HASH = Animator.StringToHash("Summoning");


    //Shooter variables

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletMoveSpeed;
    [SerializeField] private int burstCount;
    [SerializeField] private float projectilePerBurst;
    [SerializeField][Range(0, 359)] private float angleSpread;
    [SerializeField] private float startingDistance = 0.1f;
    [SerializeField] private float timeBetweenBursts;
    [SerializeField] private float restTime = 1f;
    [SerializeField] private bool stagger;
    [Tooltip("Stagger has to be enable for oscillate to work properly.")]
    [SerializeField] private bool oscillate;

    public bool stopMoving = false;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        summonLocation = GetComponent<SummonLocation>();
        enemyHealth = GetComponent<EnemyHealth>();
        summoner = GetComponent<Summoner>();

    }

    private void Update()
    {
        if (stopMoving) { enemyPathFinder.StopMoving(); }
    }

    public void Attack()
    {
        if (summoner.canSummon)
        {
            myAnimator.SetTrigger(SUMMON_HASH);
        }

        if (!summoner.canSummon)
        {
            myAnimator.SetTrigger(ATTACK_HASH);
            StartCoroutine(ShootRoutine());
        }

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

    private void StopMovingAnim()
    {
        stopMoving = true;
    }

    private void ContinueMovingAnim()
    {
        stopMoving = false;
    }

    //Shooter Code
    private IEnumerator ShootRoutine()
    {
        stopMoving = true;


        float startAngle, currentAngle, angleStep, endAngle;
        float timeBetweenProjectiles = 0f;

        TargetConeOfInfluence(out startAngle, out currentAngle, out angleStep, out endAngle);

        if (stagger) { timeBetweenProjectiles = timeBetweenBursts / projectilePerBurst; }

        for (int i = 0; i < burstCount; i++)
        {
            if (!oscillate)
            {
                TargetConeOfInfluence(out startAngle, out currentAngle, out angleStep, out endAngle);
            }

            if (oscillate && i % 2 != 1)
            {
                TargetConeOfInfluence(out startAngle, out currentAngle, out angleStep, out endAngle);
            }
            else if (oscillate)
            {
                currentAngle = endAngle;
                endAngle = startAngle;
                startAngle = currentAngle;
                angleStep *= -1;
            }


            for (int j = 0; j < projectilePerBurst; j++)
            {
                Vector2 pos = FindBulletSpawnPos(currentAngle);
                GameObject newBullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
                newBullet.transform.right = newBullet.transform.position - transform.position;

                if (newBullet.TryGetComponent(out Projectile projectile))
                {
                    projectile.UpdateMoveSpeed(bulletMoveSpeed);
                }

                currentAngle += angleStep;

                if (stagger) { yield return new WaitForSeconds(timeBetweenProjectiles); }

            }

            currentAngle = startAngle;

            if (!stagger)
            {
                yield return new WaitForSeconds(timeBetweenBursts);
            }


        }

        myAnimator.SetTrigger(ATTACKANIMSTOP_HASH);
        yield return new WaitForSeconds(restTime);
        stopMoving = false;
    }

    private void TargetConeOfInfluence(out float startAngle, out float currentAngle, out float angleStep, out float endAngle)
    {
        Vector2 targetDirection = PlayerController.Instance.transform.position - transform.position;
        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        startAngle = targetAngle;
        endAngle = targetAngle;
        currentAngle = targetAngle;
        float halfAngleSpread = 0f;
        angleStep = 0;

        //Cone of Influence

        if (angleSpread != 0f)
        {
            angleStep = angleSpread / (projectilePerBurst - 1);
            halfAngleSpread = angleSpread / 2f;
            startAngle = targetAngle - halfAngleSpread;
            endAngle = targetAngle + halfAngleSpread;
            currentAngle = startAngle;
        }
    }

    private Vector2 FindBulletSpawnPos(float currentAngle)
    {
        float x = transform.position.x + startingDistance * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float y = transform.position.y + startingDistance * Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        Vector2 pos = new(x, y);

        return pos;
    }

}
