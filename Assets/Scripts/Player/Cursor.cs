using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cursor : MonoBehaviour
{
    Vector2 last_position;
    public Player play_character;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (play_character.is_grapple)
            {
                transform.position = play_character.grapple_position;

            }

        //if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        //{
            //Vector2 mouse_pixel_pos = Mouse.current.position.ReadValue();

            //last_position = Camera.main.ScreenToWorldPoint(new Vector3(mouse_pixel_pos.x, mouse_pixel_pos.y, 10));

            //Debug.DrawRay(transform.position, play_character.rel_position * 100f, Color.black);
        //}
    }
}
