using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject winMenu;
    public GameObject dieMenu;

    void Start()
    {
        PlayerController.OnBlockysDead += OpenDead;
        PlayerController.OnBlockyWon += OpenWin;
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
