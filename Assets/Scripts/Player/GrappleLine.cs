using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(LineRenderer))]
public class GrappleLine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Player play_character;
    public Transform origin;
    public Transform grapple;
    LineRenderer lineRenderer;
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.useWorldSpace = true;

        if (lineRenderer.material == null)
        {
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.startColor = Color.black;
            lineRenderer.endColor = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (origin != null && Mouse.current.leftButton.isPressed && play_character.is_grapple)
        {
            lineRenderer.SetPosition(0, origin.position);
            lineRenderer.SetPosition(1, grapple.position);
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
