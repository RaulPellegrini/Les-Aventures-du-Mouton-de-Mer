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

    public bool flip = false;

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
            spriteRenderer.flipX = true;
            flip = true;

        } else if (moveDir.x > 0) { 
            spriteRenderer.flipX=false;
            flip = false;
       
        }
    }

    public void MoveTo(Vector2 targetPosition)
    {
        Debug.Log(targetPosition.x + " " + targetPosition.y);
        moveDir = targetPosition;
    }


    public void StopMoving()
    {
        moveDir = Vector3.zero;
    }
}
