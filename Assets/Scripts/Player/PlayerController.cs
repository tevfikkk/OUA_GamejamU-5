using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerController Settings")]
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    [Space(10)]

    // Wall Jump Properties
    [Header("Wall Sliding Properties")]
    [SerializeField] private float wallSlidingSpeed = 2f;
    private bool isWallSliding;

    [Space(10)]

    [Header("Wall Jump Properties")]
    [SerializeField] private float wallJumpingDirection;
    [SerializeField] private float wallJumpingTime = 0.2f;
    [SerializeField] private float wallJumpingCounter;
    [SerializeField] private float wallJumpingDuration = 0.4f;
    [SerializeField] private Vector2 wallJumpingPower = new Vector2(8f, 16f);
    [SerializeField] private bool isWallJumping;

    private Player player;

    private float horizontal;
    private Rigidbody2D rb;
    private bool isFacingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        WallSlide();
        // WallJump();

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * player.Speed, rb.velocity.y);
    }

    /// <summary>
    /// If holding the jump button, the player will jump higher.
    /// If not, the player will jump for a shorter duration depending upon the jump button release time.
    /// </summary>
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (context.canceled && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded() => Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    /// <summary>
    /// Responsible for flipping the player.
    /// </summary>
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    /// <summary>
    /// Take the horizontal input from the player.
    /// </summary>
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    /// <summary>
    /// Wall sliding.
    /// </summary>
    private void WallSlide()
    {
        if (isWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    /// <summary>
    /// Check if the player is walled.
    /// </summary>
    private bool isWalled() => Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);

    // private void WallJump()
    // {
    //     if (isWallSliding)
    //     {
    //         isWallJumping = false;
    //         wallJumpingDirection = isFacingRight ? 1 : -1;
    //         wallJumpingCounter = wallJumpingTime;

    //         CancelInvoke(nameof(StopWallJumping)); // Cancel the stop wall jumping method.
    //     }
    //     else
    //     {
    //         wallJumpingCounter -= Time.deltaTime;
    //     }

    //     if (wallJumpingCounter > 0)
    //     {
    //         isWallJumping = true;
    //         rb.velocity = new Vector2(wallJumpingPower.x * wallJumpingDirection, wallJumpingPower.y);
    //         wallJumpingCounter = 0f;

    //         if (transform.localScale.x != wallJumpingDirection)
    //         {
    //             isFacingRight = !isFacingRight;
    //             Vector3 localScale = transform.localScale;
    //             localScale.x *= -1f;
    //             transform.localScale = localScale;
    //         }

    //         // Invoke the stop wall jumping method.
    //         Invoke(nameof(StopWallJumping), wallJumpingDuration);
    //     }
    // }

    // private void StopWallJumping()
    // {
    //     isWallJumping = false;
    // }

}
