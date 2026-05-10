using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Sprite door_0;
    public Sprite door_1;
    public Key class_key;

    SpriteRenderer sp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (class_key.isOpen)
        {
            int nextLevel = int.Parse(SceneManager.GetActiveScene().name) + 1;
            SceneManager.LoadScene(nextLevel.ToString());
        }
    }

    public void OpenDoor()
    {
        sp.sprite = class_key.isOpen ? door_1 : door_0;
    }
}