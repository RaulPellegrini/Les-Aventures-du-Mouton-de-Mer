using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirFloat = 2f;
    [SerializeField] private float attackRange = 0f;
    [SerializeField] private float chasingRange = 5f;
    [SerializeField] private float chasingChangeDirFloat = .2f;
    [SerializeField] private float caitingStartRange = 0f;
    [SerializeField] private float caitingEndRange = 0f;

    [SerializeField] private MonoBehaviour enemyType;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private bool stopMovingWhileAttacking = false;
    [SerializeField] private bool guarding = false;


    public bool caiting = false;
    public bool chaising = false;


    private State state;
    private EnemyPathFinder enemyPathFinder;


    private bool stopRoaming = false;
    private bool canAttack = true;
           
    private Vector2 roamPosition;
    private float timeRoaming = 0f;
    
 
    private float timeChasing = 4f;
    private Vector2 direction;

    private enum State
    {
        Chasing,
        Roaming,
        Attacking,
        Caiting,
    }

    public void Awake()
    {
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        state = State.Roaming;
    }

    private void Start()
    {
        roamPosition = GetRoamingPosition();

    }

    private void Update()
    {
        MovementStateControl();
    }

    private void MovementStateControl()
    {
        switch(state)
        {
            default:
            case State.Roaming:
                Roaming();
            break;

            case State.Attacking:
                Attacking();
            break;

            case State.Chasing:
                Chasing();
            break;

            case State.Caiting: 
                Caiting(); 
            break;

  
        }
    }


    private void Roaming()
    {

        if (!stopRoaming && !guarding)
        {

            timeRoaming += Time.deltaTime;
            enemyPathFinder.MoveTo(roamPosition);


            if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) <= chasingRange)
            {
                
                stopRoaming = true;
                state = State.Chasing;
            }

            if (timeRoaming > roamChangeDirFloat)
            {
                roamPosition = GetRoamingPosition();
            }
        }
        else 
        {
            state = State.Chasing; 
        }
        
    }

    private void Chasing()
    {
        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) > chasingRange)
        {
            chaising = false;
            stopRoaming = false;
            enemyPathFinder.StopMoving();
            state = State.Roaming;
        }

        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) < caitingStartRange && caiting)
        {
            chaising = false;
            state = State.Caiting;
        }


        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) < attackRange && canAttack)
        {
            chaising = false;
            state = State.Attacking;
        }

        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) <= chasingRange)
        {
            chaising = true;
            timeChasing += Time.deltaTime;
            enemyPathFinder.MoveTo(direction);

            if (timeChasing > chasingChangeDirFloat)
            {
                direction = GetChasingPosition();
            }
        }
        else
        {
            chaising = false;
            state = State.Roaming;
        }

    }

    private void Caiting ()
    {
        if (caiting)
        {
            if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) < attackRange && canAttack)
            {
                state = State.Attacking;
            }

            if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) < caitingStartRange)
            {
                timeChasing += Time.deltaTime;
                enemyPathFinder.MoveAway(direction);

                if (timeChasing > chasingChangeDirFloat)
                {
                    direction = GetChasingPosition();
                }

            }


            if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) > caitingEndRange)
            {
                state = State.Roaming;
            }
        }
        else
        {
            state = State.Roaming;
        }

    }

    private void Attacking()
    {

        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) > attackRange)
        {
            state = State.Chasing;
        }

        if (attackRange !=0 && canAttack)
        {
            canAttack = false;
            (enemyType as IEnemy).Attack();
             StartCoroutine(AttackCooldownRoutine());

            if (stopMovingWhileAttacking)
            {
                enemyPathFinder.StopMoving();

            } else {

                enemyPathFinder.MoveTo(roamPosition);
            }

        }
    }

    private IEnumerator AttackCooldownRoutine()
    {
        state = State.Roaming;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private Vector2 GetRoamingPosition()
    {

        timeRoaming = 0f;
        return new Vector2(Random.Range(-1F, 1f), Random.Range(-1f, 1f)).normalized;

    }

    private Vector2 GetChasingPosition()
    {
        timeChasing = 0f;
        direction = (PlayerController.Instance.transform.position - transform.position).normalized;
        
        return direction;
        
    }

}
