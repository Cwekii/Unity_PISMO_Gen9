using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerFarm : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 moveInput;

    private bool interactInput;

    private Vector2 facingDirection;

    public LayerMask interactLayerMask;

    public Rigidbody2D rb;

    public SpriteRenderer sr;

    private void Start()
    {
        facingDirection = Vector2.left/2;
    }
    private void Update()
    {
        if(moveInput.magnitude != 0.0f)
        {
            facingDirection = moveInput.normalized;
            sr.flipX = moveInput.x > 0;
        }

        if(interactInput)
        {
            TryInteractTile();
            interactInput = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput.normalized * moveSpeed;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            interactInput = true;
        }
    }

    private void TryInteractTile()
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position - new Vector2(0,0.5f) + facingDirection, Vector3.up, 0.1f, interactLayerMask);
        Debug.DrawRay((Vector2)transform.position, facingDirection/2, Color.red, 0.5f);

        if(hit.collider != null)
        {
            FieldTile tile = hit.collider.GetComponent<FieldTile>();
            tile.Interact();
        }

        else
        {
            Debug.Log("Didn't hit!");
        }
    }
}
