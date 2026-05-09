using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Sprite door_0;
    public Sprite door_1;
    SpriteRenderer sp;

    Player player_character;
    Rigidbody2D player_body;
    //GameObject key;
    //Key class_key;
    Key key;
    int lvl_num = 1;
    
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

        //key = class_key.GetComponent<GameObject>();
        key = FindAnyObjectByType<Key>();
        player_character = FindAnyObjectByType<Player>();
        player_body = player_character.GetComponent<Rigidbody2D>();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (class_key.isOpen)
        if (key.isOpen)
        {
            lvl_num++;
            SceneManager.LoadScene($"Level {lvl_num}");
        }
    }

    public void OpenDoor()
    {
        //if (class_key.isOpen)
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