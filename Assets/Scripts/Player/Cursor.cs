using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cursor : MonoBehaviour
{
    public Player play_character;
    Renderer cursor_render;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cursor_render = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (play_character.is_grapple)
        {   
            Vector2 rel_pos = play_character.init_rel_position;

            transform.position = play_character.grapple_position;
            
            transform.rotation = Quaternion.FromToRotation(Vector2.up, rel_pos);
        }

        if (Mouse.current != null && Mouse.current.leftButton.isPressed && play_character.is_grapple)
        {
            cursor_render.enabled = true;
        }
        else
        {
            cursor_render.enabled = false;
        }
    }
}
