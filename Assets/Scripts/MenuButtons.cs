using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void QuitGame()
    { 
        Application.Quit();
    }

    public void NextScene()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(2);
    }

}
