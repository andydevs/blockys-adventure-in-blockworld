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
