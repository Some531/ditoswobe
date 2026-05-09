using UnityEngine;

public class Tree : MonoBehaviour
{
    private GameObject play_character; 

    private Collider2D myCollider;
    private Collider2D otherCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        play_character = GameObject.Find("Player");
        myCollider = GetComponent<Collider2D>();
        otherCollider = play_character.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myCollider.IsTouching(otherCollider))
        {
            gameObject.layer = 2;
        }
        else
        {
            gameObject.layer = 0;
        }
    }

}
