using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterMotor))]
    public class EnemyController : MonoBehaviour
    {
        private CharacterMotor characterMotor;
        private float ax;
        
        // Ledge detection parameters
        private const float LEDGE_OFFSET = 0.1f;
        private const float LEDGE_DEPTH = 1.0f;

        // Direction aliases
        private const int RIGHT = 1;
        private const int LEFT = -1;

        // Use this for initialization
        void Start()
        {
            characterMotor = GetComponent<CharacterMotor>();
            ax = 1;
        }

        // Update is called once per frame
        void Update()
        {
            characterMotor.SetMoveAxis(ax);
            if (Ledge(RIGHT) && !Ledge(LEFT)) { ax = -1; }
            else if (Ledge(LEFT) && !Ledge(RIGHT)) { ax = 1; }
        }

        Vector2 RayOffset(int direction)
        {
            return new Vector2(direction * (transform.localScale.x + 2*LEDGE_OFFSET), -transform.localScale.y) / 2;
        }

        bool Ledge(int direction)
        {
            return !Physics2D.Raycast((Vector2)transform.position + RayOffset(direction), Vector2.down, LEDGE_DEPTH);
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawRay(new Ray(transform.position + (Vector3)RayOffset(RIGHT), LEDGE_DEPTH * Vector3.down));
            Gizmos.DrawRay(new Ray(transform.position + (Vector3)RayOffset(LEFT),  LEDGE_DEPTH * Vector3.down));
        }
    }
}