using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnrandomBlock : MonoBehaviour
{

    public GameObject[] blockPrefabs;
    public int numberOfBlocksToSpawn = 3;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;

    void Start()
    {
        SpawnBlocks();
    }

    void SpawnBlocks()
    {
        for (int i = 0; i < numberOfBlocksToSpawn; i++)
        {
            int randomIndex = Random.Range(0, blockPrefabs.Length);
            GameObject blockPrefab = blockPrefabs[randomIndex];

            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
