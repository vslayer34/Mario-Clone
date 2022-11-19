using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Joystick joystick;

    [SerializeField] float speed = 20.0f;


    [SerializeField] float jumpForce;
    bool isJumpCalled;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        
        // adjust the hard settings of the jpystick movement
        joystick.SnapX = true;
        joystick.DeadZone = 0.3f;

        isJumpCalled = false;
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //joystick. = Input.GetAxis("Horizontal");
        if (joystick.Vertical > 0.5f)
        {
            // setting the boolean so the player can jump in the fixed update
            isJumpCalled = true;
        }
    }

    private void FixedUpdate()
    {
        Move(joystick.Horizontal);
        Jump();
    }

    void Move(float direction)
    {
        // to prevent the player from moving in the slightest changes to the joystick
        if (direction >= 0.5f)
        {
            rb.velocity = new Vector2(direction * speed * Time.deltaTime, rb.velocity.y);
            spriteRenderer.flipX = false;
        }
        else if (direction <= -0.5f)
        {
            rb.velocity = new Vector2(direction * speed * Time.deltaTime, rb.velocity.y);
            spriteRenderer.flipX = true;
        }
        else
            rb.velocity = new Vector2(0, rb.velocity.y);
    }

    void Jump()
    {
        // only jumping when the buttom is pressed and the player is on the ground
        if (isJumpCalled && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    public void Die()
    {
        Debug.Log($"{gameObject.name} died!!!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Make sure the player is on the ground to prevent jumbing in the air
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumpCalled = false;
        }
            
    }
}
