using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButtonManager : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("3");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void GameEnd()
    {
        Application.Quit();
    }

}
