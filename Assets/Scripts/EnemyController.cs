using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterMotor))]
    public class EnemyController : MonoBehaviour, IKillable
    {
        // Ledge detection parameters
        public float ledgeOffset  = 0.1f;
        public float ledgeDepth   = 1.0f;
        public Vector2 hitBoxSize = new Vector2(1.1f, 1);

        // Components
        private CharacterMotor motor;

        // Direction aliases
        private const int RIGHT = 1;
        private const int LEFT = -1;

        // Use this for initialization
        void Start()
        {
            motor = GetComponent<CharacterMotor>();
            motor.SetMoveAxis(RIGHT);
        }

        // Update is called once per frame
        void Update()
        {
            // Set axis based on ledge
            float xRayOffset       = transform.localScale.x + 2 * ledgeOffset;
            Vector2 rayOffsetRight = new Vector2(RIGHT * xRayOffset, -transform.localScale.y) / 2;
            Vector2 rayOffsetLeft  = new Vector2(LEFT * xRayOffset, -transform.localScale.y) / 2;
            Vector2 rayOriginRight = (Vector2)transform.position + rayOffsetRight;
            Vector2 rayOriginLeft  = (Vector2)transform.position + rayOffsetLeft;
            bool ledgeRight        = !Physics2D.Raycast(rayOriginRight, Vector2.down, ledgeDepth);
            bool ledgeLeft         = !Physics2D.Raycast(rayOriginLeft, Vector2.down, ledgeDepth);
            bool onlyLedgeRight    = ledgeRight && !ledgeLeft;
            bool onlyLedgeLeft     = ledgeLeft && !ledgeRight;
            if (onlyLedgeRight) { motor.SetMoveAxis(LEFT); }
            else if (onlyLedgeLeft) { motor.SetMoveAxis(RIGHT); }

            // Check if we hit that meddling blocky
            int collisionMask = LayerMask.GetMask("Player");
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, hitBoxSize, 0, Vector2.right, 1, collisionMask);
            if (hit.collider != null) {
                Debug.Log("Aaaah I gotchu blocky muahahahah");
                hit.collider.GetComponent<IKillable>().Kill();
            }
        }

        // Called when gizmos are being drawn (editor or player)
        void OnDrawGizmos()
        {
            // Ledge lines
            float xRayOffset = transform.localScale.x + 2 * ledgeOffset;
            Vector2 rayOffsetRight = new Vector2(RIGHT * xRayOffset, -transform.localScale.y) / 2;
            Vector2 rayOffsetLeft  = new Vector2(LEFT * xRayOffset,  -transform.localScale.y) / 2;
            Vector2 rayOriginRight = (Vector2)transform.position + rayOffsetRight;
            Vector2 rayOriginLeft  = (Vector2)transform.position + rayOffsetLeft;
            Vector2 lineDirection = ledgeDepth * Vector3.down;

            // Draw Gizmos
            Gizmos.DrawLine(rayOriginRight, rayOriginRight + lineDirection);
            Gizmos.DrawLine(rayOriginLeft, rayOriginLeft + lineDirection);
            Gizmos.DrawCube(transform.position, new Vector3(hitBoxSize.x, hitBoxSize.y, 1));
        }
        
        // Kill this boi
        public void Kill()
        {
            Debug.Log("Gaaahhh ya got me!");
            Destroy(gameObject);
        }
    }
}