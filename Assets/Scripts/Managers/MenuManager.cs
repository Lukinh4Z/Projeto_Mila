using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuCanvasGO;
    private bool _isPaused;
    void Start()
    {
        _pauseMenuCanvasGO.SetActive(false);
    }

    private void Update()
    {
        if(InputManager.Instance.MenuOpenCloseInput)
        {
            if(!_isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    #region Pause/Unpause Functions
    private void Pause()
    {
        Time.timeScale = 0f;
        _isPaused = true;

        OpenPauseMenu();
    }

    public void Unpause()
    {
        Time.timeScale = 1.0f;
        _isPaused = false;

        CloseAllMenus();
    }

    #endregion

    #region Canvas Activations/Deactivations

    private void OpenPauseMenu()
    {
        _pauseMenuCanvasGO.SetActive(true);
    }

    private void CloseAllMenus()
    {
        _pauseMenuCanvasGO.SetActive(false);

    }

    #endregion

    public void CleanHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

}
