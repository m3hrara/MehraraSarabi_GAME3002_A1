using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void LoadMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }
    public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void LoadTutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }
    public void Exit()
    {
        Application.Quit();
    }
}