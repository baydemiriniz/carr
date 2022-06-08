using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Test Level")]
    public Level testLevel;
    [Header("Level List")]
    public List<Level> Levels = new List<Level>();

    public void CreateLevel()
    {
        if (testLevel != null)
        {
            Instantiate(testLevel, new Vector3(0, 0, 0), Quaternion.identity);
            return;
        }
        else
        {
            if (PlayerPrefs.GetInt("CurrentLevel") == 0)
            {
                Instantiate(Levels[0], new Vector3(0, 0, 0), Quaternion.identity);
                // PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
            }
            else
            {
                if (PlayerPrefs.GetInt("CurrentLevel") >= Levels.Count)
                {
                    PlayerPrefs.SetInt("CurrentLevel", 0);
                }
                Instantiate(Levels[PlayerPrefs.GetInt("CurrentLevel")], new Vector3(0, 0, 0), Quaternion.identity);
            }

        }
    }
}