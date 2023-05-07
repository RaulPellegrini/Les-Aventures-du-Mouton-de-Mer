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

    public bool movingLeft = false;
    public bool isflipped = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        knockback = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (knockback.GettingKnockedBack){ return ; }
                
        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));

        if (moveDir.x < 0)
        {
            movingLeft = true;
            if (movingLeft == true && moveDir.x < 0 && isflipped == false)
            {
                flipping();
                //spriteRenderer.flipX=true;
                isflipped = true;
            }

        } else if (moveDir.x > 0 && isflipped == true) 
        {
            movingLeft = false;
            flipping();
            //spriteRenderer.flipX=false;
            isflipped = false;
       
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

    private void flipping()
    {
        Vector3 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }
}
