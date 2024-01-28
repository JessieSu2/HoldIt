using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void QuitGame()
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundEffects.ClickSound);
        Application.Quit();
    }

    public void NextScene()
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundEffects.ClickSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void RestartGame()
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundEffects.ClickSound);
        SceneManager.LoadScene(3);
    }

    public void GoToCreditScene()
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundEffects.ClickSound);
        SceneManager.LoadScene(5);
    }

    public void GoToMainScreen()
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundEffects.ClickSound);
        SceneManager.LoadScene(0);
    }

}
