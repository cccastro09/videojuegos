﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject MenuPause;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
       
    }

    void resume()
    {
        MenuPause.SetActive(false);
        GameIsPause = false;
        Time.timeScale = 1f;
    }


    void pause()
    {
        MenuPause.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void reiniciar()
    {
        SceneManager.LoadScene("ExpVirtual");
        GameIsPause = false;
        Time.timeScale = 1f;
    }

    public void salir()
    {
        Application.Quit();
    }
}