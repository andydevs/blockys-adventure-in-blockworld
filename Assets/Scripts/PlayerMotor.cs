using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float moveForce = 10;
    public float jumpForce = 500;

    float x;
    float jump;
    bool jumped;
    bool grounded;
    Vector2 spawn;
    Rigidbody2D r2d;

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        spawn = transform.position;
    }

    void Update()
    {
        // Get x and jump axes
        x = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");

        // Check if grounded
        Debug.DrawRay(transform.position, Vector2.down*1.1f, Color.white);
        grounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f);
    }

    void FixedUpdate()
    {
        // Move left/right
        r2d.AddForce(Vector2.right * x * moveForce);

        // Jump
        if (jump > 0 && !jumped && grounded) {

            // Check if grounded
            r2d.AddForce(Vector2.up * jumpForce);
            jumped = true;
        }
        if (jump == 0) { jumped = false; }
    }

    public void Respawn() {
        transform.position = spawn;
    }
}
