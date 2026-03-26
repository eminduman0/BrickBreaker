using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 8f;
    public Collider2D playerCollider;
    public Collider2D ballCollider;

    private bool isLaunched = false;
    private Transform player;

    public GameObject endGamePanel;
    public HeartManager heartManager;

    public ScoreManager scoreManager;
    public EndGameUI endGameUI;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        ResetBall();
    }

    void Update()
    {
        if (!isLaunched)
        {
            Vector3 pos = player.position;
            pos.y += playerCollider.bounds.extents.y + ballCollider.bounds.extents.y;
            transform.position = pos;

            if (Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.Space))
            {
                Launch();
            }
        }

        float bottomY = Camera.main.transform.position.y - Camera.main.orthographicSize;
        if (transform.position.y < bottomY)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.failSound);
            BallMissed();
        }
    }
    void Launch()
    {
        isLaunched = true;
        float x = Random.Range(-1f, 1f);
        Vector2 dir = new Vector2(x, 1).normalized;
        rb.linearVelocity = dir * speed;
    }
    void ResetBall()
    {
        isLaunched = false;
        rb.linearVelocity = Vector2.zero;
        Vector3 pos = player.position;
        pos.y += playerCollider.bounds.extents.y + ballCollider.bounds.extents.y;
        transform.position = pos;
    }

    void BallMissed()
    {
        heartManager.LoseLife();

        if (heartManager.GetLives() <= 0)
        {
            EndGame();
        }
        else
        {
            ResetBall();
        }
    }

    void EndGame()
    {
        rb.linearVelocity = Vector2.zero;
        isLaunched = false;
        endGamePanel.SetActive(true);
        endGameUI.Show();
        Time.timeScale = 0f; // oyunu durdur
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isLaunched) return;

        FixBallDirection();

        if (collision.gameObject.CompareTag("Player"))
        {
            float paddleX = collision.transform.position.x;
            float hitX = transform.position.x;
            float fark = hitX - paddleX;

            Vector2 newDir = new Vector2(fark, 1).normalized;
            rb.linearVelocity = newDir * speed;

            AudioManager.instance.PlaySFX(AudioManager.instance.ballHit);
            scoreManager.ResetCombo();
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.ballHit);
        }
    }

    void FixBallDirection()
    {
        Vector2 dir = rb.linearVelocity.normalized;

        if (Mathf.Abs(dir.y) < 0.3f)
        {
            dir.y = 0.5f * Mathf.Sign(dir.y == 0 ? 1 : dir.y);
        }

        rb.linearVelocity = dir.normalized * speed;
    }
}