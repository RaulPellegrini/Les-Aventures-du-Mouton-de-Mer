using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;

public class KnightBoss : MonoBehaviour, IEnemy
{

    [SerializeField] GameObject secondPhaseVFX;

    private Animator myAnimator;
    private EnemyPathFinder enemyPathFinder;
    private EnemyHealth enemyHealth;
    private Summoner summoner;


    readonly int ATTACK_HASH = Animator.StringToHash("Attack");
    readonly int ATTACK2_HASH = Animator.StringToHash("Attack2");



    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        enemyHealth = GetComponent<EnemyHealth>();
        summoner = GetComponent<Summoner>();
    }

    private void Update()
    {
        if (enemyHealth.halfHealth == true)
        {
            InitiateVFX();
            summoner.Summoning();
        }
    }

    private void InitiateVFX()
    {
        secondPhaseVFX.SetActive(true);
    }


    public void Attack()
    {

        if (enemyHealth.halfHealth == true)
        {
            myAnimator.SetTrigger(ATTACK2_HASH);
            SideDetection();

        }

        else
        {
            myAnimator.SetTrigger(ATTACK_HASH);
            SideDetection();

        }
    

    }

    private void SideDetection()
    {
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

