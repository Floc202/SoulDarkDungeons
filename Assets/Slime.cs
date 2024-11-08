using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Damageble))]
public class Slime : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float walkStopRate = 0.05f;
    public DetectionZone cliffDetectionZone;

    Rigidbody2D rb;
    TouchingDirections touchingDirections;
    Damageble damageble;
    Animator animator;

    public enum WalkableDirection { Left, Right }

    private WalkableDirection _walkDirection;
    private Vector2 walkDirectionVector = Vector2.left;

    public WalkableDirection WalkDirection
    {
        get { return _walkDirection; }
        set
        {
            if (_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if (value == WalkableDirection.Right)
                {
                    walkDirectionVector = Vector2.left;
                }
                else if (value == WalkableDirection.Left)
                {
                    walkDirectionVector = Vector2.right;
                }
            }

            _walkDirection = value;
        }
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        damageble = GetComponent<Damageble>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (touchingDirections.IsGrounded && touchingDirections.IsOnWall || cliffDetectionZone.detectedColliders.Count == 0)
        {
            FlipDirection();
        }
        if (!damageble.IsHit)
        {
            if (CanMove)
                rb.velocity = new Vector2(walkSpeed * walkDirectionVector.x, rb.velocity.y);
            else
                rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, walkSpeed), rb.velocity.y);
        }

    }

    private void FlipDirection()
    {
        if (WalkDirection == WalkableDirection.Left)
        {
            WalkDirection = WalkableDirection.Right;
        }
        else if (WalkDirection == WalkableDirection.Right)
        {
            WalkDirection = WalkableDirection.Left;
        }
        else
        {
            Debug.LogError("Current walkable direction is not set to legal values of right or left");
        }
    }

    public void OnHit(int damage, Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }

    public void OnCliffDetected()
    {
        if (touchingDirections.IsGrounded)
        {
            FlipDirection();
        }
    }
}
