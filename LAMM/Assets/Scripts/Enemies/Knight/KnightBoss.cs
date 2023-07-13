using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class KnightBoss : MonoBehaviour, IEnemy
{
    [SerializeField] GameObject Walls;
    [SerializeField] GameObject secondPhaseVFX;
    [SerializeField] private float secondPhaseAttackRange = 8f;
    [SerializeField] GameObject WeaponCollider;
    [SerializeField] GameObject WeaponCollider2;
    [SerializeField] GameObject WeaponCollider3;
    [SerializeField] GameObject WeaponCollider4;


    private Animator myAnimator;
    private EnemyPathFinder enemyPathFinder;
    private EnemyHealth enemyHealth;
    private Summoner summoner;
    private EnemyAI enemyAI;
    private MagicWall magicWall;


    readonly int ATTACK_HASH = Animator.StringToHash("Attack");
    readonly int ATTACK2_HASH = Animator.StringToHash("Attack2");
    readonly int SUMMONING_HASH = Animator.StringToHash("Summoning");


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        enemyPathFinder = GetComponent<EnemyPathFinder>();
        enemyHealth = GetComponent<EnemyHealth>();
        summoner = GetComponent<Summoner>();
        enemyAI = GetComponent<EnemyAI>();
        magicWall = Walls.GetComponent<MagicWall>();
        
    }

    private void Update()
    {
        if (enemyHealth.threeQuarterHealth)
        {
            if (summoner.canSummon)
            {
                myAnimator.SetTrigger(SUMMONING_HASH);
                summoner.canSummon = false;
            }

            SideDetection();
            InitiateVFX();
        }

    }

    private void InitiateVFX()
    {
        secondPhaseVFX.SetActive(true);
        enemyAI.attackRange = secondPhaseAttackRange;
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

    private void OnDestroy()
    {
        magicWall.WallsOff();
    }

    private void WeaponColliderStart()
    {
        WeaponCollider.SetActive(true);
    }

    private void WeaponColliderStop()
    {
        WeaponCollider.SetActive(false);
    }

    private void WeaponCollider2Start()
    {
        WeaponCollider2.SetActive(true);
    }

    private void WeaponCollider2Stop()
    {
        WeaponCollider2.SetActive(false);
    }

    private void WeaponCollider3Start()
    {
        WeaponCollider3.SetActive(true);
    }

    private void WeaponCollider3Stop()
    {
        WeaponCollider3.SetActive(false);
    }

    private void WeaponCollider4Start()
    {
        WeaponCollider4.SetActive(true);
    }

    private void WeaponCollider4Stop()
    {
        WeaponCollider4.SetActive(false);
    }




}

