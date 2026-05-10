using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    Vector2 initial_position;
    Vector2 reset_position;
    Vector2 rel_position;
    Quaternion original_rotation;
    Quaternion proj_split = Quaternion.Euler(0f, 0f, 20f);
    float jump_time = 1f;
    float proj_time = 3f;
    public float jump_power = 5f;
    public float patrol_distance = 5f;
    public float speed = 5f;
    public float gravity = 0.05f;
    public float hit_speed = 3f;
    public float health = 100f;
    public float proj_speed = 3f;
    public SpriteRenderer sp;
    public GameObject bullet_pre;
    public GameObject obj_player;
    //Player cls_player;
    //Rigidbody2D bdy_player;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        initial_position = transform.position;
        jump_time = Random.Range(5f, 20f);
        //bdy_player = obj_player.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityX = speed;
        obj_player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocityY -= gravity;
        if (jump_time > 0)
        {
            jump_time -= Time.deltaTime;
        }
        else
        {
            Jump();
            jump_time = Random.Range(3f, 6f);
        }
        if (proj_time > 0)
        {
            proj_time -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Bang");
            Shoot();
            proj_time = Random.Range(0.75f * proj_speed, 1.5f * proj_speed);
        }
        if (transform.position.y < initial_position.y && rb.linearVelocityY < 0)
        {
            rb.linearVelocityY = 0;
            reset_position = new Vector2(transform.position.x, initial_position.y);
            transform.position = reset_position;
        }
        //if (transform.position.y < initial_position.y)
        //{
            //reset_position = new Vector2(transform.position.x, initial_position.y);
            //transform.position = reset_position;
        //}
        if (initial_position.x - patrol_distance >= transform.position.x)
        {
            rb.linearVelocityX = speed;
            sp.flipX = !sp.flipX;
        }

        if (initial_position.x + patrol_distance <= transform.position.x)
        {
            rb.linearVelocityX = -speed;
            sp.flipX = !sp.flipX;
        }

        if (health <= 0)
        {
            int nextLevel = int.Parse(SceneManager.GetActiveScene().name) + 1;
            SceneManager.LoadScene(nextLevel.ToString());
        }

    }

    void Jump()
    {
        rb.linearVelocityY = jump_power;
        reset_position = new Vector2(transform.position.x, initial_position.y + 1f);
        transform.position = reset_position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.linearVelocity.magnitude > hit_speed)
        {
            health -= rb.linearVelocity.magnitude;
        }
    }

    void Shoot()
    {
        rel_position = new Vector2(obj_player.transform.position.x - transform.position.x, 
                                   obj_player.transform.position.y - transform.position.y);
        original_rotation = Quaternion.FromToRotation(Vector2.up, rel_position);
        Instantiate(bullet_pre, transform.position, original_rotation);
        Instantiate(bullet_pre, transform.position, original_rotation * proj_split);
        Instantiate(bullet_pre, transform.position, original_rotation * Quaternion.Inverse(proj_split));
    }
}
