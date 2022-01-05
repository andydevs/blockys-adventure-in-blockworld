using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class GameStateController : MonoBehaviour
    {
        // Events
        public delegate void PauseEvent();
        public static event PauseEvent OnPause;
        public delegate void CloseUIEvent();
        public static event CloseUIEvent OnCloseUI;
        public delegate void SpawnABlockyEvent();
        public static event SpawnABlockyEvent OnSpawnABlocky;

        public void OnStart(InputValue val)
        {
            if (PlayerController.BlockyIsAlive())
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
            Time.timeScale = 0.0f;
            OnPause();
        }

        public void Resume()
        {
            Time.timeScale = 1.0f;
            OnCloseUI();
        }

        public void Restart()
        {
            OnSpawnABlocky();
            OnCloseUI();
        }

        public void Quit()
        {
            Debug.Log("Quit application...");
            Application.Quit(0);
        }
    }
}