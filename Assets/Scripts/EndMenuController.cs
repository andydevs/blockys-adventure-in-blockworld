using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class EndMenuController : MonoBehaviour
    {
        public void BackToStart()
        {
            SceneManager.LoadScene(0);
        }

        public void Quit()
        {
            Debug.Log("Quit Application...");
            Application.Quit(0);
        }
    }
}