using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool isOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Player player_character;
    Rigidbody2D player_body;
    Door door;

    void Start()
    {
        isOpen = false;

        door = GameObject.FindAnyObjectByType<Door>();
        player_character = FindAnyObjectByType<Player>();
        player_body = player_character.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("kachink");
        isOpen = true;
        gameObject.SetActive(false);
        door.OpenDoor();
    }
}
