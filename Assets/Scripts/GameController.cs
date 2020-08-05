using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    SpawnPoint spawnPoint;
    UISystem ui;

    // Start is called before the first frame update
    void Start()
    {
        // Get controllers
        spawnPoint = GameObject
            .FindWithTag("Respawn")
            .GetComponent<SpawnPoint>();
        ui = GameObject
            .FindWithTag("UI")
            .GetComponent<UISystem>();
    }

    public void BlockysDead()
    {
        ui.DeadUI();
    }

    public void BlockyWon()
    {
        ui.WinnerUI();
    }

    public void Restart()
    {
        ui.ResetUI();
        spawnPoint.SpawnABlocky();
    }

    public void Quit()
    {
        Application.Quit(0);
    }
}
