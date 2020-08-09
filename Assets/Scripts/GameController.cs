using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Sub objects
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ui.IsPaused()) Resume();
            else Pause();
        }
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

    public void Pause()
    {
        ui.PauseUI();
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        ui.UnpauseUI();
        Time.timeScale = 1f;
    }
}
