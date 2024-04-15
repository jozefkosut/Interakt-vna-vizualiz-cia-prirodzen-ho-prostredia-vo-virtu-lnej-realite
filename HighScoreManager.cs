using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshPro T_highScore;
    private int highScore;
    private int highScore2;
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "ArcheryScene")
        {
            highScore = PlayerPrefs.GetInt("HighScore_Archery", 0);
            T_highScore.text = "High Score: " + highScore;
        }
        else if (sceneName == "Sword_training")
        {
            highScore2 = PlayerPrefs.GetInt("HighScore_Sword", 0);
            T_highScore.text = "High Score: " + highScore2;
        }
    }
    public void UpdateHighScore(int currentScore)
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string prefKey = "";
        if (sceneName == "ArcheryScene")
        {
            if (currentScore > highScore)
            {
                highScore = currentScore;
                prefKey = "HighScore_Archery";
            }
        }
        else if (sceneName == "Sword_training")
        {
            if (currentScore > highScore2)
            {
                highScore2 = currentScore;
                prefKey = "HighScore_Sword";
            }
        }
        if (!string.IsNullOrEmpty(prefKey))
        {
            PlayerPrefs.SetInt(prefKey, currentScore);
            PlayerPrefs.Save();
            T_highScore.text = "High Score: " + currentScore;
        }
    }
}
