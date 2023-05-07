using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knight : MonoBehaviour, IEnemy
{
    [SerializeField] GameObject KnightWeapon;

    private Animator myAnimator;
    private SpriteRenderer spriteRenderer;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");


    public void Awake()
    {

        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void Attack()
    {

        myAnimator.SetTrigger(ATTACK_HASH);

        
        /* if (transform.position.x - PlayerController.Instance.transform.position.x < 0)
         {
             spriteRenderer.flipX = false;
         }
         else
         {
             spriteRenderer.flipX = true;
         }
        */
    }


}

