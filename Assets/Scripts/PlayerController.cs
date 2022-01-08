using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterMotor))]
    public class PlayerController : MonoBehaviour, IKillable
    {
        public static bool BlockyIsAlive()
        {
            PlayerController[] blockys = FindObjectsOfType<PlayerController>();
            return blockys.Length > 0;
        }

        // Events
        public delegate void BlockysDeadEvent();
        public static event BlockysDeadEvent OnBlockysDead;
        public delegate void BlockyWonEvent();
        public static event BlockyWonEvent OnBlockyWon;

        // Components
        CharacterMotor motor;

        // Start is called before the first frame update
        void Start()
        {
            motor = GetComponent<CharacterMotor>();
        }

        // Move when movement axis is given
        public void OnMove(InputValue val)
        {
            motor.SetMoveAxis(val.Get<float>());
        }

        // Jump when jump button pressed
        public void OnJump(InputValue val)
        {
            motor.Jump();
        }

        // Kill condition
        public void Kill()
        {
            Debug.Log("Oh noes I izz kill");
            Destroy(gameObject);
            OnBlockysDead();
        }

        // Win condition
        public void Win()
        {
            Debug.Log("I deeed it!");
            Destroy(gameObject);
            OnBlockyWon();
        }
    }
}