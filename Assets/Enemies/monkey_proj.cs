using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_proj : MonoBehaviour
{
    public Vector2 startPos; 
    public float moveSpeed;
    public SpriteRenderer sp;
    public float patrolDistance;
    public float kill_speed;
    Player player_character;
    Rigidbody2D player_body;
    static public List<GameObject> dead_enemies = new List<GameObject>();

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        startPos = transform.position;
        player_character = FindAnyObjectByType<Player>();
        player_body = player_character.GetComponent<Rigidbody2D>();
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
        dead_enemies.Add(gameObject);
        gameObject.SetActive(false);
    }

    static public void Respawn(GameObject enemy)
    {
        enemy.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (player_body.GetPointVelocity(transform.position).magnitude > kill_speed)
        {
            player_character.ReflectVertical();
            Death();
        }
    }
}