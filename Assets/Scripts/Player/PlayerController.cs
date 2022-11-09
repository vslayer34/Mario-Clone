using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    private float speed = 5.0f;
    private float movementX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move(movementX);
    }

    void Move(float direction)
    {
        //Vector2 pos = (Vector2)transform.position;
        //rb.MovePosition(pos + (direction * speed * Time.deltaTime));
        Vector2 pos = (Vector2)transform.position;
        rb.MovePosition(new Vector2(pos.x + (direction * speed * Time.deltaTime), transform.position.y));
    }
}
