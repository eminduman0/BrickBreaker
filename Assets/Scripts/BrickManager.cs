using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrickManager : MonoBehaviour
{
    public GameObject blockPrefab;
    public Sprite[] brickSprites; // 8 sprite

    public int rows = 4;
    public int columns = 7;

    public float xSpacing = 1.8f;
    public float ySpacing = 1.0f;

    public Vector2 topCenter = new Vector2(0f, 2.67f);

    private List<GameObject> blocks = new List<GameObject>();

    void Start()
    {
        SpawnNewGrid();
    }

    public void SpawnNewGrid()
    {
        StartCoroutine(SpawnAnimation());
    }

    IEnumerator SpawnAnimation()
    {
        blocks.Clear();

        // 8 sprite arasından 4 farklı seç (aynı satır tekrar etmesin)
        List<int> usedIndexes = new List<int>();

        for (int row = 0; row < rows; row++)
        {
            int randomIndex;

            do
            {
                randomIndex = Random.Range(0, brickSprites.Length);
            }
            while (usedIndexes.Contains(randomIndex));

            usedIndexes.Add(randomIndex);

            for (int col = 0; col < columns; col++)
            {
                float startX = -(columns - 1) * xSpacing / 2;

                Vector3 targetPos = new Vector3(
                    startX + col * xSpacing,
                    topCenter.y - row * ySpacing,
                    0
                );

                // yukarıdan spawn
                Vector3 spawnPos = targetPos + Vector3.up * 5f;

                GameObject block = Instantiate(blockPrefab, spawnPos, Quaternion.identity, transform);

                // sprite ata
                block.GetComponent<SpriteRenderer>().sprite = brickSprites[randomIndex];

                // scale ayarla
                block.transform.localScale = new Vector3(5f, 2.5f, 1f);

                blocks.Add(block);

                // aşağı düşme animasyonu
                StartCoroutine(MoveToPosition(block, targetPos));
            }
        }

        yield return null;
    }

    IEnumerator MoveToPosition(GameObject obj, Vector3 target)
    {
        float time = 0f;
        Vector3 start = obj.transform.position;

        while (time < 1f)
        {
            if (obj == null) yield break;

            time += Time.deltaTime * 2f;
            obj.transform.position = Vector3.Lerp(start, target, time);
            yield return null;
        }

        if (obj != null)
            obj.transform.position = target;
    }

    public void BlockDestroyed(GameObject block)
    {
        blocks.Remove(block);
        Destroy(block);

        if (blocks.Count == 0)
        {
            SpawnNewGrid();
        }
    }
}