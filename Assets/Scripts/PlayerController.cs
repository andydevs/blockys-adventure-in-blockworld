using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class PlayerController : MonoBehaviour
{
    // Components
    GameController game;
    CharacterMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize Game Object
        game = GameObject
            .FindWithTag("GameController")
            .GetComponent<GameController>();
        motor = GetComponent<CharacterMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get x and jump axes
        motor.SetMoveAxis(Input.GetAxis("Horizontal"));
        motor.SetJumpAxis(Input.GetAxis("Jump"));
    }

    public void Kill()
    {
        // Print a message
        Debug.Log("Oh noes I izz kill");

        // Daaaa....
        Destroy(gameObject);

        // Notify game of our demise
        game.BlockysDead();
    }

    public void Win()
    {
        // Print a message
        Debug.Log("I deeed it!");

        // Daaa?
        Destroy(gameObject);

        // Notify game of our Victory
        game.BlockyWon();
    }
}
