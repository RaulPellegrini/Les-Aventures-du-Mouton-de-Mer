using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator myAnimator;

    readonly int UP_HASH = Animator.StringToHash("Up");
    readonly int DOWN_HASH = Animator.StringToHash("Down");
    readonly int RESET_HASH = Animator.StringToHash("Reset");

    public bool up = true;
    public bool down = false;
    public bool reset = false;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            myAnimator.SetTrigger(DOWN_HASH);
            up = false;
            down = true;
        }

    }
    public void ButtonReset()
    {
        myAnimator.SetTrigger(RESET_HASH);
    }

    private void ResetEnd()
    {
        myAnimator.SetTrigger(UP_HASH);
        up = true;
        down = false;
    }
}
