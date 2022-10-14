using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    bool GameIsPause;
    GameObject pauseMenuUI;
    GameObject streetEngineGO;
    StreetEngine streetEngineScript;

    private void Start()
    {
        pauseMenuUI = GameObject.Find("PausePanel");
        pauseMenuUI.SetActive(false);
        GameIsPause = false;
        streetEngineGO = GameObject.Find("StreetEngine");
        streetEngineScript = streetEngineGO.GetComponent<StreetEngine>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && streetEngineScript.gameStart)
        {
            if (GameIsPause)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPause = false;
        AudioListener.pause = false;
    }
    
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        AudioListener.pause = true;
    }
}
