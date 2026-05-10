using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] public Camera main_camera;
    RaycastHit2D grappleHit;  
    public Vector2 rel_position;
    public Vector2 grapple_position;
    public bool is_grapple = false;
    [SerializeField] LayerMask layerMask;

    public float thrust = 50f;
    public float detection_distance = 20f;
    public float bounce = 2f;
    Rigidbody2D rb;
    Vector2 mouse_world_pos = Vector2.zero;   
    Vector2 direction;
    Vector2 player_position;
    Vector2 mouse_pixel_pos;
    Vector2 initial_position;
    public static bool isOpen = false;
    GameObject dead_key;
    Door door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        initial_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        player_position = transform.position;

        Debug.DrawRay(player_position, rel_position * thrust);
        
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {

            player_position = transform.position;

            mouse_pixel_pos = Mouse.current.position.ReadValue();

            mouse_world_pos = Camera.main.ScreenToWorldPoint(new Vector3(mouse_pixel_pos.x, mouse_pixel_pos.y, 0));

            direction = new Vector2(mouse_world_pos.x - player_position.x, mouse_world_pos.y - player_position.y).normalized;

            grappleHit = Physics2D.Raycast(transform.position, direction, detection_distance, layerMask);

            if (grappleHit)
            {
                is_grapple = true;

                grapple_position = grappleHit.point;
            }
            else
            {
                is_grapple = false;
            }
        }

        rel_position = new Vector2(grapple_position.x - player_position.x, grapple_position.y - player_position.y).normalized;
    }

    void FixedUpdate()
    {
        if (Mouse.current != null && Mouse.current.leftButton.isPressed && grappleHit)
        {
            rb.AddForce(rel_position * thrust);
        }
    }

    public void ReflectVertical()
    {
        if (rb.linearVelocityY < 0)
        {
            rb.linearVelocityY = -rb.linearVelocityY + bounce;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        door = FindAnyObjectByType<Door>();
        if (collision.gameObject.CompareTag("hazard"))
        {
            Respawn();
            foreach (GameObject enemy in Enemy.dead_enemies)
            {
                Enemy.Respawn(enemy);
            }
            foreach (GameObject enemy in Enemy_proj.dead_enemies)
            {
                Enemy_proj.Respawn(enemy);
            }
            if (isOpen)
            {
                isOpen = false;
                dead_key.SetActive(true);
                door.OpenDoor();
            }
        }
        if (collision.gameObject.CompareTag("key"))
        {
            isOpen = true;
            dead_key = collision.gameObject;
            dead_key.SetActive(false);
            door.OpenDoor();
        }
    }

    void Respawn()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = initial_position;
    }
}
