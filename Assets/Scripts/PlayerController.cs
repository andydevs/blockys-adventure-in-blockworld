using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterMotor))]
public class PlayerController : MonoBehaviour
{
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

    public void OnMove(InputValue val)
    {
        motor.SetMoveAxis(val.Get<float>());
    }

    public void OnJump(InputValue val)
    {
        motor.Jump();
    }

    public void Kill()
    {
        Debug.Log("Oh noes I izz kill");
        Destroy(gameObject);
        OnBlockysDead();
    }

    public void Win()
    {
        Debug.Log("I deeed it!");
        Destroy(gameObject);
        OnBlockyWon();
    }
}
