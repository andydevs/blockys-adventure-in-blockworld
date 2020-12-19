using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    // Sub objects
    SpawnPoint spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Get controllers
        spawnPoint = GameObject
            .FindWithTag("Respawn")
            .GetComponent<SpawnPoint>();
    }

    public void OnStart(InputValue val)
    {
    }

    public void BlockysDead()
    {
        spawnPoint.SpawnABlocky();
    }

    public void BlockyWon()
    {
        spawnPoint.SpawnABlocky();
    }

    public void Restart()
    {
    }

    public void Quit()
    {
        Application.Quit(0);
    }
}
