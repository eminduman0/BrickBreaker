using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rgb;
    public float speed = 12f;
    public float minX = -7f;
    public float maxX = 7f;

    float move;

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        Vector2 newPos = rgb.position + Vector2.right * move * speed * Time.fixedDeltaTime;
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        rgb.MovePosition(newPos);
    }
}
