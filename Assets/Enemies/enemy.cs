using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float moveSpeed;
    public SpriteRenderer sp;
    public float patrolDistance = 3;

    public Vector2 startPos; 


    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        startPos = transform.position;
    }

    private void Update()
    {
        Move();
        
    }


    protected virtual void Move()
    {
        float currentX = transform.position.x;
         
        float time = Mathf.PingPong(Time.time * moveSpeed, 1);
        
        // 4. Lerp between minX and maxX based on time
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