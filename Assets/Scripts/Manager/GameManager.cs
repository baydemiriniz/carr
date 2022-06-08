using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public LevelManager levelManager;
    public UIManager UIManager;
    [Header("Panels")] 
    public GameObject nextLevelPanel;
    public GameObject retryLevelPanel;
    public GameObject tapToStartLevelPanel;
    public GameObject joystickGameObject;
    public FixedJoystick dynamicJoystick;
    public void Start()
    {
        Instance = this;
        levelManager.CreateLevel();
    }

    #region LevelState
    public void LevelWon()
    {
        //TODO:Level Won
        SceneManager.LoadScene("Monster truck 1");
        PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
    }

    public void LevelFail()
    {
        //TODO:Level Retry
        SceneManager.LoadScene("Monster truck 1");
    }

    public void PreviousLevel()
    {
        if (levelManager.testLevel == null && PlayerPrefs.GetInt("CurrentLevel") > 0)
        {
            SceneManager.LoadScene("Monster truck 1");
            PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") - 1);
        }
    }
    #endregion
    #region PanelState

    public void RetryLevelPanel()
    {
        retryLevelPanel.SetActive(true);
    }

    public void WonLevelPanel()
    {
        nextLevelPanel.SetActive(true);
    }

    public void TapToStartLevelPanel()
    {
        tapToStartLevelPanel.SetActive(false);
        joystickGameObject.SetActive(true);
    }

    #endregion
}