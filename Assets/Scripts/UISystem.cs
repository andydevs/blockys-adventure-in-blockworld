using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    // Sub UI
    GameObject deadUI;
    GameObject winnerUI;
    GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        deadUI = transform.Find("Dead UI").gameObject;
        winnerUI = transform.Find("Winner UI").gameObject;
        pauseUI = transform.Find("Pause UI").gameObject;
        ResetUI();
    }

    public void DeadUI()
    {
        Debug.Log("RIP Blocky");
        deadUI.SetActive(true);
    }

    public void WinnerUI()
    {
        Debug.Log("They did it!");
        winnerUI.SetActive(true);
    }

    public void PauseUI()
    {
        Debug.Log("Paused!");
        pauseUI.SetActive(true);
    }

    public void ResetUI()
    {
        Debug.Log("Start Again!");
        winnerUI.SetActive(false);
        deadUI.SetActive(false);
        pauseUI.SetActive(false);
    }
}
