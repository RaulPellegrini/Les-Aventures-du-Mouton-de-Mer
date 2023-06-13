using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    private EnemyPathFinder enemyPathFinder;
    private FairyBow fairyBow;

    private void Awake()
    {
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        fairyBow = GetComponentInChildren<FairyBow>();

    }

    private void Update()
    {
        BowCheck();
    }

    private void BowCheck()
    {
        if (enemyPathFinder.facingRight == true)
        {
            fairyBow.aimingRight = true;
        }

        if (enemyPathFinder.facingRight == false)
        {
            fairyBow.aimingRight = false;
        }
    }

}
