using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Awake()
    {
        Time.timeScale = 1.0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Home Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
