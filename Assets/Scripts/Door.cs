using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite door_0;
    public Sprite door_1;

    private SpriteRenderer spriteRenderer;
    private bool isOpen = false;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void SetState(isOpen)
    {
        if (isOpen)
        {
            spriteRenderer.sprite = door_1;
        }
        else
        {
            spriteRenderer.sprite = door_0;
        }
    }
}