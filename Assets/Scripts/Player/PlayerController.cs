using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Joystick joystick;

    [SerializeField] float speed = 20.0f;
    float movementX;


    [SerializeField] float jumpForce;
    bool isJumpCalled;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        joystick.SnapX = true;
        //joystick.SnapY = true;
        joystick.DeadZone = 0.3f;
        rb = GetComponent<Rigidbody2D>();
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
        if (direction >= 0.5f)
            rb.velocity = new Vector2(direction * speed * Time.deltaTime, rb.velocity.y);
        else if (direction <= -0.5f)
            rb.velocity = new Vector2(direction * speed * Time.deltaTime, rb.velocity.y);
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
