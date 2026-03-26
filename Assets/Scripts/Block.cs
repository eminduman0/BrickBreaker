using UnityEngine;

public class Block : MonoBehaviour
{
    private BrickManager brickManager;
    private ScoreManager scoreManager;

    void Start()
    {
        brickManager = FindObjectOfType<BrickManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.ballHit);
            scoreManager.AddScore();
            brickManager.BlockDestroyed(gameObject);
        }
    }
}