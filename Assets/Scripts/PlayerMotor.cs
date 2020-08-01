using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour
{
    // Motion Parameters
    public float moveMaxVelocity = 20;
    public float moveForce = 10;
    public float jumpForce = 500;

    // Motion Axes
    float move;
    float jump;

    // Spawn point
    Vector2 spawn;

    // Components
    Rigidbody2D r2d;

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        spawn = transform.position;
    }

    void Update()
    {
        // Get x and jump axes
        SetMoveAxis(Input.GetAxis("Horizontal"));
        SetJumpAxis(Input.GetAxis("Jump"));
    }

    void FixedUpdate()
    {
        // Only if Grounded
        if (IsGrounded())
        {
            // Move left/right if below velocity
            if (r2d.velocity.sqrMagnitude < moveMaxVelocity*moveMaxVelocity)
            {
                r2d.AddForce(Vector2.right * move * moveForce);
            }
            
            // Jump
            if (jump > 0)
            {
                r2d.AddForce(Vector2.up * jumpForce);
            }
        }
    }

    public void SetMoveAxis(float val)
    {
        move = val;
    }

    public void SetJumpAxis(float val)
    {
        jump = val;
    }

    public bool IsLeftGrounded()
    {
        return Physics2D.Raycast(transform.position + Vector3.left*0.45f, Vector2.down, 1.1f);
    }

    public bool IsRightGrounded()
    {
        return Physics2D.Raycast(transform.position + Vector3.right*0.45f, Vector2.down, 1.1f);
    }

    public bool IsGrounded()
    {
        return IsLeftGrounded() || IsRightGrounded();
    }

    public void Respawn() 
    {
        transform.position = spawn;
    }
}
