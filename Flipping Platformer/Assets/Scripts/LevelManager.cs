using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentIndex);
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadWinMenu()
    {
        SceneManager.LoadScene("WinMenu");
    }

    public void LoadLoseMenu()
    {
        SceneManager.LoadScene("LoseMenu");
    }

    public void LoadCreditsMenu()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

}
