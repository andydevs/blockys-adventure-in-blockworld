using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class UIController : MonoBehaviour
    {
        // UI Menus
        public GameObject pauseMenu;
        public GameObject winMenu;
        public GameObject dieMenu;

        void Start()
        {
            // Hook into events
            PlayerController.OnBlockysDead += OpenDead;
            PlayerController.OnBlockyWon += OpenWin;
            GameStateController.OnPause += OpenPause;
            GameStateController.OnCloseUI += CloseAll;
        }

        public void CloseAll()
        {
            pauseMenu.SetActive(false);
            winMenu.SetActive(false);
            dieMenu.SetActive(false);
        }

        public void OpenPause()
        {
            pauseMenu.SetActive(true);
        }

        public void OpenWin()
        {
            winMenu.SetActive(true);
        }

        public void OpenDead()
        {
            dieMenu.SetActive(true);
        }
    }
}