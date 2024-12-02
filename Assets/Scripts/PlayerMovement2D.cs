using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y) * moveSpeed;
        rb.velocity = move;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
