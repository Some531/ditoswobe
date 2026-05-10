using UnityEngine;

public class Key : MonoBehaviour
{
    public bool isOpen;
    Door door;

    void Start()
    {
        isOpen = false;
        door = FindAnyObjectByType<Door>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Debug.Log("Key collected!");
        isOpen = true;
        gameObject.SetActive(false);
        door.OpenDoor();
    }

    public void Respawn()
    {
        isOpen = false;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }


}