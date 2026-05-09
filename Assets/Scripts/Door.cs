using UnityEngine;

public class Door2 : MonoBehaviour
{
    public Sprite door_0;
    public Sprite door_1;

    private SpriteRenderer spriteRenderer;
    private bool isOpen = false;
    
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void Update()
    {
        
    }

    public void SetState(bool isOpen)
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