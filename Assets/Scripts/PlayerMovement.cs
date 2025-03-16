using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpOffset;
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private LayerMask groundMask;

    private bool isOnGround = false;

    private void FixedUpdate()
    {
        Vector3 overlapCircePosition = groundColliderTransform.position;
        isOnGround = Physics2D.OverlapCircle(overlapCircePosition, jumpOffset, groundMask);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        int[] myarra = {2,3};

    }
    public void Move(float horizontalDirection, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
