using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class StartMenuController : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void Quit()
        {
            Debug.Log("Quit Application...");
            Application.Quit(0);
        }
    }
}