using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float maxDistance;
    Rigidbody2D rb;

    [SerializeField] float speed;
    SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;

    // bool to detect whether the enemy is alice or dear
    bool isAlive;
    // bool to determine movement direction defalut = true towards the player
    bool moveLeft;

    // to get the player script
    [SerializeField] GameObject player;
    private PlayerController target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        moveLeft = true;
        isAlive = true;

        target = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));
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
        isAlive = false;
        animator.SetBool("Is Hit", true);
        Debug.Log($"{gameObject.name} Died!!!");
        StartCoroutine("DelayDestroy");
        //Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
            moveLeft = !moveLeft;
        }

        if (collision.gameObject.CompareTag("Player") && isAlive)
        {
            target.Hit();
        }
    }


    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
