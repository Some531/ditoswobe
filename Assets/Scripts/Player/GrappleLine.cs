using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GrappleLine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Player player_character;
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
    void FixedUpdate()
    {
        if (origin != null && player_character.is_grapple)
        {
            lineRenderer.SetPosition(0, origin.position);
            lineRenderer.SetPosition(1, grapple.position);
        }
    }
}
