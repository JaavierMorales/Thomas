using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask layerCompatible;

    public float speed, jumpForce, distanceGround;
    private Rigidbody2D rb;
    private float horizontal;
    public bool isGround;
    public float acceleration, deceleration;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        Debug.DrawRay(transform.position, Vector2.down * distanceGround, Color.red);

        if (Physics2D.Raycast(transform.position, Vector2.down, distanceGround, layerCompatible))
        {
            isGround = true;
        }
        else isGround = false;

        if (Input.GetKeyDown(KeyCode.W) && isGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        // Acelerar o desacelerar gradualmente
        if (horizontal > 0 && rb.velocity.x < speed)
        {
            rb.velocity = new Vector2(Mathf.Min(rb.velocity.x + acceleration * Time.deltaTime, speed), rb.velocity.y);
        }
        else if (horizontal < 0 && rb.velocity.x > -speed)
        {
            rb.velocity = new Vector2(Mathf.Max(rb.velocity.x - acceleration * Time.deltaTime, -speed), rb.velocity.y);
        }
        else if (horizontal == 0)
        {
            // Desacelerar si no hay entrada
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, deceleration * Time.deltaTime), rb.velocity.y);
        }
    }
}

