using UnityEngine;
using TMPro;

public class EndGameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highText;

    public ScoreManager scoreManager;

    public void Show()
    {
        scoreManager.SaveHighScore();

        int score = scoreManager.GetScore();
        int high = scoreManager.GetHighScore();

        scoreText.text = "Score: " + score.ToString("D5");
        highText.text = "High: " + high.ToString("D5");

        gameObject.SetActive(true);
    }
}