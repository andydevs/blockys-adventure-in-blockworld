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
        public float bounceHeight = 10;

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

        // Update is called once per frame
        void Update()
        {
            // Enemy hit detection
            int collisionMask = LayerMask.GetMask("Enemy");
            RaycastHit2D enemyHit = Physics2D.BoxCast(
                (Vector2)transform.position + Vector2.down * (transform.localScale.y + boxSize.y) / 1.98f,
                boxSize, 0, Vector2.down, 1f, collisionMask);
             
            // If collided with enemy
            if (enemyHit.collider != null) 
            {
                Debug.Log("It's over enemy! I have the High Ground");
                enemyHit.collider.GetComponent<EnemyController>().Kill();
                GoUp(bounceHeight);
            }
        }

        // Called when drawing gizmos
        void OnDrawGizmos()
        {
            Gizmos.DrawCube((Vector2)transform.position + Vector2.down * (transform.localScale.y + boxSize.y) / 1.98f, boxSize);
        }

        // Do the up-direction-going physics
        void GoUp(float height)
        {
            jumpVelocity = Mathf.Sqrt(2 * r2d.gravityScale * height);
            r2d.velocity = new Vector2(r2d.velocity.x, jumpVelocity);
        }

        // Set move axis command
        public void SetMoveAxis(float val)
        {
            move = val;
        }
        
        // Jump command
        public void Jump()
        {
            // Ground detection
            int collisionMask = LayerMask.GetMask("Terrain");
            bool grounded = Physics2D.BoxCast(
                (Vector2)transform.position + Vector2.down * (transform.localScale.y + boxSize.y) / 1.98f,
                boxSize, 0, Vector2.down, 1f, collisionMask);
            
            // Jump only if blocky is grounded
            if (grounded) GoUp(jumpHeight);
        }
    }
}