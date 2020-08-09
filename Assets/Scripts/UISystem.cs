using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    // Sub UI
    UIWindow deadUI;
    UIWindow winnerUI;
    UIWindow pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        deadUI = transform.Find("Dead UI").GetComponent<UIWindow>();
        winnerUI = transform.Find("Winner UI").GetComponent<UIWindow>();
        pauseUI = transform.Find("Pause UI").GetComponent<UIWindow>();
        ResetUI();
    }

    public bool IsPaused()
    {
        return pauseUI.IsActive();
    }

    public void PauseUI()
    {
        Debug.Log("Paused!");
        pauseUI.Activate();
    }

    public void UnpauseUI()
    {
        Debug.Log("Unpaused!");
        pauseUI.Deactivate();
    }

    public void DeadUI()
    {
        Debug.Log("RIP Blocky");
        deadUI.Activate();
    }

    public void WinnerUI()
    {
        Debug.Log("They did it!");
        winnerUI.Activate();
    }

    public void ResetUI()
    {
        Debug.Log("Start Again!");
        winnerUI.Deactivate();
        deadUI.Deactivate();
        pauseUI.Deactivate();
    }
}
