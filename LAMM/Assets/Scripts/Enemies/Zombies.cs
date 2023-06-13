using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour, IEnemy
{
    private Animator myAnimator;
    private FadeToRed fadeToRed;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");


    public void Awake()
    {
        myAnimator = GetComponent<Animator>();
        fadeToRed = GetComponent<FadeToRed>();

    }

    public void Attack()
    {
        myAnimator.SetTrigger(ATTACK_HASH);
        fadeToRed.ColorChangeToFinal();

    }

    public void Explode()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }
}
