using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
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
            r2d.velocity = new Vector2(moveVelocity * move, r2d.velocity.y);
        }

        public void SetMoveAxis(float val)
        {
            move = val;
        }

        public void Jump()
        {
            if (IsGrounded())
            {
                jumpVelocity = Mathf.Sqrt(2 * r2d.gravityScale * jumpHeight);
                r2d.velocity = new Vector2(r2d.velocity.x, jumpVelocity);
            }
        }

        public bool IsGrounded()
        {
            return Physics2D.BoxCast(
                (Vector2)transform.position + Vector2.down * transform.localScale.y,
                new Vector2(0.8f, 0.5f),
                transform.rotation.z, Vector2.down, 0.1f);
        }
    }
}