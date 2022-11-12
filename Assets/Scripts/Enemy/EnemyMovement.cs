using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float maxDistance;
    Rigidbody2D rb;

    [SerializeField] float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }
}
