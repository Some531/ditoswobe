using UnityEngine;
using UnityEngine.LowLevelPhysics2D;

public class Bullet : MonoBehaviour
{
    public float proj_life = 1f;
    public float proj_speed = 3f;
    Vector3 chg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chg = transform.position;
        chg.z = 10f;
        transform.position = chg;
        Destroy(gameObject, proj_life);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * proj_speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
