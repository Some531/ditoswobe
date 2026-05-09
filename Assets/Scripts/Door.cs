using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Sprite door_0;
    public Sprite door_1;
    SpriteRenderer sp;

    Player player_character;
    Rigidbody2D player_body;
    Key key;
    
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

        key = GameObject.FindAnyObjectByType<Key>();
        player_character = FindAnyObjectByType<Player>();
        player_body = player_character.GetComponent<Rigidbody2D>();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (key.isOpen)
        {
            SceneManager.LoadScene($"Level {lvl_num}");
            
        }
    }

    public void OpenDoor()
    {
        if (key.isOpen)
        {
            sp.sprite = door_1;
        }
        else
        {
            sp.sprite = door_0;
        }
    }
}