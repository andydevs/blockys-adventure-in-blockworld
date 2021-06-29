using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    // UI Menus
    public GameObject pauseMenu;
    public GameObject winMenu;
    public GameObject dieMenu;

    // Spawn point game objects
    SpawnPoint spawnPoint;

    void Start()
    {
        // Hook into player events
        PlayerController.OnBlockysDead += OpenDead;
        PlayerController.OnBlockyWon += OpenWin;

        // Find spawn point
        spawnPoint = GameObject
            .Find("Spawn Point")
            .GetComponent<SpawnPoint>();
    }

    public void OnStart(InputValue val)
    {
        Debug.Log("Blocky is alive? " + spawnPoint.BlockyIsAlive());
        if (spawnPoint.BlockyIsAlive())
        {
            Debug.Log("Currently paused?: " + IsPaused());
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
        OpenPause();
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        CloseAll();
        Time.timeScale = 1.0f;
    }

    public void CloseAll()
    {
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        dieMenu.SetActive(false);
    }

    public void OpenPause()
    {
        CloseAll();
        pauseMenu.SetActive(true);
    }

    public void OpenWin()
    {
        CloseAll();
        winMenu.SetActive(true);
    }

    public void OpenDead()
    {
        CloseAll();
        dieMenu.SetActive(true);
    }
}
