using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public GameObject[] hearts; // 3 kalp

    private int lives;

    void Start()
    {
        lives = hearts.Length;
    }

    public void LoseLife()
    {
        lives--;

        if (lives >= 0 && lives < hearts.Length)
        {
            hearts[lives].SetActive(false);
        }
    }

    public int GetLives()
    {
        return lives;
    }
}