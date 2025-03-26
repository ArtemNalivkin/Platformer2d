using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Movement Vars")]
    [SerializeField] private float jumpForce;

    [Header("Settings")]
    [SerializeField] private AnimationCurve speedCurve;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Vector2 raycastBoxSize;
     
    private bool isGrounded = false;
    private bool isFlipped = false;

    private void FixedUpdate()
    {
        CheckGround();
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

    }

    private void Awake()
    {
        isFlipped = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void Move(float movementDirection, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
        {
            Jump();
        }

        // Flip the character depending on direction
        if (movementDirection > 0 && isFlipped)
        {
            transform.localScale = new Vector3(1, 1, 1); // Facing right
            isFlipped = false;
        }
        else if (movementDirection < 0 && !isFlipped)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing left (flipped)
            isFlipped = true;
        }

        if (Mathf.Abs(movementDirection) > 0.01f)
        {
            HorizontalMovement(movementDirection);
        }
    }

    private void Jump()
    {
        if (isGrounded) //если на земле и не имеем вертикальной скорости
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }
    }

    private void HorizontalMovement(float movementDirection)
    {
        rb.velocity = new Vector2(speedCurve.Evaluate(movementDirection), rb.velocity.y);
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.BoxCast(transform.position, raycastBoxSize, 0, -transform.up, groundCheckDistance, groundLayer);
        
        if (isGrounded && rb.velocity.y < 0.1f)
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up*groundCheckDistance, raycastBoxSize);
    }

}
