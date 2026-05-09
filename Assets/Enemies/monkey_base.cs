using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Vector2 startPos; 
    public float moveSpeed;
    public SpriteRenderer sp;
    public float patrolDistance;



    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        Move();
        
    }


    protected virtual void Move()
    {
        float currentX = transform.position.x;
         
        float newX = currentX + moveSpeed;
        
        // 5. Update position
        if (-patrolDistance <= (newX - startPos.x) && (newX - startPos.x) <= patrolDistance)
        {
            transform.position = new Vector2(newX, transform.position.y);
        }
        else
        {
            sp.flipX = !sp.flipX;
            moveSpeed = moveSpeed * -1;
        }
    }


    protected virtual void Death()
    {
        Destroy(gameObject);
    }

}