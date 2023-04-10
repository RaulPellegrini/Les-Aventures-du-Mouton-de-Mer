using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirFloat =2f;

    private enum State
    {
        Roaming
    }

    private State state;
    private EnemyPathFinder enemyPathFinder;

    private void Awake()
    {
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        state = State.Roaming;
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());

    }

    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming) 
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathFinder.MoveTo(roamPosition);
            yield return new WaitForSeconds(roamChangeDirFloat);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1F, 1f), Random.Range(-1f, 1f)).normalized;

    }

}
