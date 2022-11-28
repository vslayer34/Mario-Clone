using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float maxDistance;
    Rigidbody2D rb;

    [SerializeField] float speed;
    SpriteRenderer spriteRenderer;
    
    bool moveLeft;              // bool to determine movement direction defalut = true towards the player
    
    // to get the player script
    [SerializeField] GameObject player;
    private PlayerController target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        moveLeft = true;

        target = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (moveLeft)
        {
            spriteRenderer.flipX = true;
            rb.velocity = new Vector2(-speed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else if (!moveLeft)
        {
            spriteRenderer.flipX = false;
            rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
        }
    }

    public void Die()
    {
        Debug.Log($"{gameObject.name} Died!!!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            bool collisiobOccoured = false;
            if (collisiobOccoured)
                return;
            if (!collisiobOccoured)
            {
                moveLeft = !moveLeft;
                collisiobOccoured = true;
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            target.Hit();
        }
    }
}
