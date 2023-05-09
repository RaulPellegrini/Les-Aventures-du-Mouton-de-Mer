using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinder : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    //[SerializeField] private float moveCooldown = 1f;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private Knockback knockback;
    private SpriteRenderer spriteRenderer;
    //Moving the animation control to here
    
    private Animator myAnimator;

    private bool canMove = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        knockback = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();
        //Moving the animation control to here
        myAnimator = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        if (knockback.GettingKnockedBack) { return; }
        if (!canMove) { return; }

        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
        
        if (moveDir.x < 0)
        {
            spriteRenderer.flipX = true;

        }
        else if (moveDir.x > 0)
        {
            spriteRenderer.flipX = false;

        }
    }

    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = targetPosition;
    }

    public void StopMoving()
    {

        moveDir = Vector3.zero;

    }
    public void StopMoveStart()
    {

        canMove = false;
        moveDir = Vector3.zero;
        //StartCoroutine(WaitBeforeMoveRotine());

    }

    public void StopMoveEnd()
    {
        canMove = true;
    }

    /*private IEnumerator WaitBeforeMoveRotine()
    {
 
        moveDir = Vector3.zero;
        yield return new WaitForSeconds(moveCooldown);
        canMove = true;
    }
    */

}
