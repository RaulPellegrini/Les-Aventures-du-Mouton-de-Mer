using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinder : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private bool canMove = true;
    public bool facingRight = true;

    readonly int WALKING_HASH = Animator.StringToHash("Walking");

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private Knockback knockback;
    private Animator myAnimator;

    private void Awake()
    {
        knockback = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (knockback.GettingKnockedBack) { return; }
        if (!canMove) { return; }

        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
        
        DirectionCheck();

    }

    public void DirectionCheck()
    {
        if (moveDir.x < 0 && facingRight == true)
        {
            Flip();
            facingRight = false;
            //spriteRenderer.flipX = true;
        }
        else if (moveDir.x > 0 && facingRight == false)
        {

            Flip();
            facingRight = true;
            //spriteRenderer.flipX = false;
        }

    }

    public void MoveTo(Vector2 targetPosition)
    {
        myAnimator.SetBool(WALKING_HASH, true);
        moveDir = targetPosition;
    }

    public void MoveAway(Vector2 targetPosition)
    {
        myAnimator.SetBool(WALKING_HASH, true);
        moveDir = -targetPosition;
    }
    public void StopMoving()
    {
        myAnimator.SetBool(WALKING_HASH, false);
        
        moveDir = Vector3.zero;
    }
    public void StopMoveStart()
    {
        myAnimator.SetBool(WALKING_HASH, false);

        canMove = false;
        moveDir = Vector3.zero;
    }

    public void StopMoveEnd()
    {
        canMove = true;
    }

    public void Flip()
    {

       facingRight = !facingRight;
       Vector3 theScale = transform.localScale;
       theScale.x *= -1;
       transform.localScale = theScale;
    }
}
