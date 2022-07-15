using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    
    public void Title()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");

    }

    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");

    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("it's working!");

    }

}
