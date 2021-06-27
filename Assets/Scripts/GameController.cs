using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    // Sub objects
    SpawnPoint spawnPoint;
    UIController uiController;

    // Start is called before the first frame update
    void Start()
    {
        // Get sub objects
        spawnPoint = GetComponentInChildren<SpawnPoint>();
        uiController = GetComponentInChildren<UIController>();
    }

    public void OnStart(InputValue val)
    {
        Debug.Log(spawnPoint.BlockyIsAlive());
        if (spawnPoint.BlockyIsAlive())
        {
            if (IsPaused()) Resume();
            else Pause();
        }
    }

    public bool IsPaused()
    {
        return Time.timeScale < 0.5f;
    }

    public void Pause()
    {
        uiController.OpenPause();
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        uiController.CloseAll();
        Time.timeScale = 1.0f;
    }

    public void Restart()
    {
        uiController.CloseAll();
        spawnPoint.SpawnABlocky();
    }

    public void Quit()
    {
        Debug.Log("Quit application...");
        Application.Quit(0);
    }
}
