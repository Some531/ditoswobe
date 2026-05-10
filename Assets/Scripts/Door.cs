using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Sprite door_0;
    public Sprite door_1;
    public GameObject obj_player;
    SpriteRenderer sp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        obj_player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Player.isOpen)
        {
            Player.isOpen = false;
            OpenDoor();
            int nextLevel = int.Parse(SceneManager.GetActiveScene().name) + 1;
            SceneManager.LoadScene(nextLevel.ToString());
        }
    }

    public void OpenDoor()
    {
        sp.sprite = Player.isOpen ? door_1 : door_0;
    }
}