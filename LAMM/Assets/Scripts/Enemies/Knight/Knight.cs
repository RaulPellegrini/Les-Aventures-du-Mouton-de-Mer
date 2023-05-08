using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knight : MonoBehaviour, IEnemy
{

    private Animator myAnimator;
    private SpriteRenderer spriteRenderer;
    private GameObject colider;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");


    public void Awake()
    {
        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
 
    }

    public void Attack()
    {
        myAnimator.SetTrigger(ATTACK_HASH);

    }
    

}

