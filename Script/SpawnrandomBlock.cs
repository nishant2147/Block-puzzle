using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnrandomBlock : MonoBehaviour
{
    float k;
    public GameObject[] blockPrefabs;
    int numberOfBlocksToSpawn = 4;
    /*public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;*/

    void Start()
    {
        SpawnBlocks();
    }

    void SpawnBlocks()
    {
        for (int i = 1; i < numberOfBlocksToSpawn; i++)
        {
            if (i == 1)
            {
                k = 0.6f;
            }
            else if (i == 2)
            {
                k = 2.7f;
            }
            else if(i == 3)
            {
                k = 5f;
            }

            var block = Instantiate(blockPrefabs[Random.Range(0, blockPrefabs.Length)],new Vector2(k,0),Quaternion.identity);
            block.transform.SetParent(transform,false);
        }
    }
}
