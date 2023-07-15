using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator myAnimator;
    [SerializeField] private float resetTime = 2f;

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
        if (other.gameObject.GetComponent<PlayerController>() && !down)
        {
            myAnimator.SetTrigger(DOWN_HASH);
            up = false;
            down = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

    }

    public void ButtonReset()
    {
        StartCoroutine(ButtonResetRoutine());
    }

    private IEnumerator ButtonResetRoutine()
    {
        myAnimator.SetTrigger(RESET_HASH);
        yield return new WaitForSeconds(resetTime);
        myAnimator.SetTrigger(UP_HASH);
        up = true;
        down = false;
    }
}
