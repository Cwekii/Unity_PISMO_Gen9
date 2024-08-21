using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllePlatform : MonoBehaviour
{
    public Rigidbody2D rb;

    public Transform groundCheck;

    public LayerMask groundLayer;

    private float horizontal;

    public float movementSpeed;
    public float jumpPower;

    private SpriteRenderer sr;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (horizontal != 0)
        {
            sr.flipX = horizontal > 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            //Gizmos.DrawWireSphere2D(groundCheck.position, 0.2f);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
