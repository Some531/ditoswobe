using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cursor : MonoBehaviour

{
    public Player play_character;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (play_character.is_grapple)
        {
            transform.position = play_character.grapple_position;
            
        }
    }
}
