﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeToGame()
    {
        SceneManager.LoadScene(1);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ToAchis()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
