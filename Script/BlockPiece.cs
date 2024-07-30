using UnityEngine;

public class BlockPiece : MonoBehaviour
{
    Vector2 startPos = Vector2.zero;
    internal bool blockPlaced = false;
    private Vector3 originalScale;
    Vector3 largedScale = new Vector3(1f, 1f, 1f);

    internal void moveToOrignalPosition()
    {
        transform.position = startPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        originalScale = transform.localScale;
    }
    void OnMouseDown()
    {
        transform.localScale = largedScale;
    }

    void OnMouseUp()
    {
        transform.localScale = largedScale;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}