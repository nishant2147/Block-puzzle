using System;
using Unity.VisualScripting;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid instance;

    // Start is called before the first frame update
    public int size;
    public GameObject tilePrefab;

    GameObject[,] baseBlock;
    GameObject[,] fillBlock;
    void Start()
    {
        baseBlock = new GameObject[size, size];
        fillBlock = new GameObject[size, size];
        instance = this;
        grid();
    }

    void grid()
    {
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                GameObject tile = Instantiate(tilePrefab, transform);
                tile.transform.position = new Vector3(col, row, 0);
                baseBlock[row, col] = tile;
            }
        }
    }

    internal bool inRange(Vector2 pos)
    {
        return pos.x > -0.5 && pos.y > -0.5 &&
            pos.x < (size - 0.5f) && pos.y < (size - 0.5);
    }
    internal bool isEmpty(BlockPiece block)
    {
        for (int i = 0; i < block.transform.childCount; i++)
        {
            var piece = block.transform.GetChild(i);
            Vector2Int pos = vectorToInt(piece.transform.position);
            print("Position.x = " + pos.x + "     |    " + pos.y);
            if (fillBlock[pos.x, pos.y])
            {
                return false;
            }
        }
        return true;
    }
    /*internal bool isempty(GameObject block2)
    {
        Vector2Int pos = vectorToInt(block2.transform.position);
        if (fillBlock[pos.x, pos.y])
        {
            return false;
        }
        return true;
    }*/
    private Vector2Int vectorToInt(Vector3 pos)
    {
        return new Vector2Int((int)(pos.x + 0.5f), (int)(pos.y + 0.5f));
    }
    internal void placeBlock(BlockPiece block)
    {
        block.blockPlaced = true;
        for (int i = 0; i < block.transform.childCount; i++)
        {
            var piece = block.transform.GetChild(i).gameObject;
            Vector2Int pos = vectorToInt(piece.transform.position);
            fillBlock[pos.x, pos.y] = piece;
            piece.transform.position = new Vector3(pos.x, pos.y);
        }
    }

    /*internal void placeBlock(GameObject block)
    {
        var piece = block.transform.GetChild(0).gameObject;
        Vector2Int pos = vectorToInt(block.transform.position);
        fillBlock[pos.x, pos.y] = piece;
        piece.transform.position = new Vector3(pos.x, pos.y);

    }*/
}