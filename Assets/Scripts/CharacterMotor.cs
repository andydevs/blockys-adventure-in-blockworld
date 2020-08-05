using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMotor : MonoBehaviour
{
    // Motion Parameters
    public float moveVelocity = 20;
    public float jumpHeight = 20;

    // Physics System
    Rigidbody2D r2d;
    float jumpVelocity;
    float move;
    float jump;

    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per physics update
    void FixedUpdate()
    {
        // Move more snappy
        r2d.velocity = new Vector2(moveVelocity*move, r2d.velocity.y);

        // Jump
        if (jump > 0 && IsGrounded())
        {
            jumpVelocity = Mathf.Sqrt(2*r2d.gravityScale*jumpHeight);
            r2d.velocity = new Vector2(r2d.velocity.x, jumpVelocity);
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
}
