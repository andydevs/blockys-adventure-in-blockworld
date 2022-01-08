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

        // Bound detection parameters
        public Vector2 boxSize = new Vector2(0.8f, 0.27f);

        // Physics System
        Rigidbody2D r2d;
        float jumpVelocity;
        float move;

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

        bool IsGrounded()
        {
            int collisionMask = LayerMask.GetMask("Terrain");
            return Physics2D.BoxCast(
                (Vector2)transform.position + Vector2.down * (transform.localScale.y + boxSize.y) / 1.98f, 
                boxSize, 0, Vector2.down, 1f, collisionMask);
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawCube((Vector2)transform.position + Vector2.down * (transform.localScale.y + boxSize.y)/1.98f, boxSize);
        }
    }
}