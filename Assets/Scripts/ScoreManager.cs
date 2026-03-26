using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score = 0;
    private int comboCount = 0;

    private int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
    }
    public void AddScore()
    {
        comboCount++;

        int gained = 50 + (comboCount - 1) * 10;
        score += gained;

        UpdateUI();
    }

    public void ResetCombo()
    {
        comboCount = 0;
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score.ToString("D5");
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void SaveHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
}