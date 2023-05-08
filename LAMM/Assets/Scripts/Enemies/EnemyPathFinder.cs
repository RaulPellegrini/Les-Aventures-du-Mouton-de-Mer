using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinder : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private Knockback knockback;
    private SpriteRenderer spriteRenderer;

    public bool flipped = false;
    public bool movingLeft = false;

    public bool facingRight = true; //Depends on if your animation is by default facing right or left

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        knockback = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (knockback.GettingKnockedBack){ return ; }
        
        FacingDirection();

        /*
        if (moveDir.x < 0)
        { 
            spriteRenderer.flipX = true;
            flip = true;

        } else if (moveDir.x > 0) { 
            spriteRenderer.flipX=false;
            flip = false;

        }
        */
    }

    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = targetPosition;
    }


    public void StopMoving()
    {
        moveDir = Vector3.zero;
    }

    private void Flipping ()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void FacingDirection() 
    {
        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));

        if (moveDir.x < 0)
        {
            movingLeft = true;
            if (moveDir.x < 0 && flipped == false)
            {
                flipped = true;
                Flipping();
            }

        }
        if (moveDir.y > 0)
        {
            movingLeft = false;
            if (moveDir.y > 0 && flipped == true)
            {
                flipped = false;
                Flipping();
            }
        }
    }

}
