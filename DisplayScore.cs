using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayScore : MonoBehaviour
{
    public TextMeshPro T_score;
    public static int score;
    public static int score2;
    private HighScoreManager highScoreManager;

    void Start()
    {
        score = 0;
        score2 = 0;
        highScoreManager = FindObjectOfType<HighScoreManager>();
    }
    void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "ArcheryScene")
        {
            T_score.text = score.ToString();
            highScoreManager.UpdateHighScore(score);
        }
        else if (currentSceneName == "Sword_training")
        {
            T_score.text = score2.ToString();
            highScoreManager.UpdateHighScore(score2);
        }
    }
}
