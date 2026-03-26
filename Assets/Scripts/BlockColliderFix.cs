using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BlockColliderFix : MonoBehaviour
{
    void Start()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        // Sprite boyutuna göre collider ayarla
        col.size = sr.sprite.bounds.size;
        col.offset = Vector2.zero;
    }
}