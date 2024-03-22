using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private bool isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0; //freezes time
        AudioListener.pause = true;//pause the audio listener (if we are using audiolistener and not audiomixer)
        //brings up pause menu
        pauseMenuUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1; //normal time
        AudioListener.pause = false;
        //puts away pause menu
        pauseMenuUI.SetActive(false);
        isPaused = false; //for the resume button
    }

}
