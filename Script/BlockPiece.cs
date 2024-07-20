using UnityEngine;

public class BlockPiece : MonoBehaviour
{
    Vector2 startPos = Vector2.zero;
    internal bool blockPlaced = false;

    internal void moveToOrignalPosition()
    {
        transform.position = startPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}