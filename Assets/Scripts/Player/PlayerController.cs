using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float speed = 20.0f;
    float movementX;


    [SerializeField] float jumpForce;
    bool isJumpCalled;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumpCalled = false;
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // setting the boolean so the player can jump in the fixed update
            isJumpCalled = true;
        }
    }

    private void FixedUpdate()
    {
        Move(movementX);
        Jump();
    }

    void Move(float direction)
    {
        rb.velocity = new Vector2(direction * speed * Time.deltaTime, rb.velocity.y);
    }

    void Jump()
    {
        // only jumping when the buttom is pressed and the player is on the ground
        if (isJumpCalled && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            isGrounded = false;
            isJumpCalled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Make sure the player is on the ground to prevent jumbing in the air
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}
