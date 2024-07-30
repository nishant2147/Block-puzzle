using UnityEngine;

public class BlockPiece : MonoBehaviour
{
    Vector2 startPos = Vector2.zero;
    internal bool blockPlaced = false;
    private Vector3 originalScale = new Vector3(0.5f,0.5f,0.5f);
    Vector3 largedScale = new Vector3(1f, 1f, 1f);
    Vector3 smallScale = new Vector3(0.5f, 0.5f, 0.5f);

    internal void moveToOrignalPosition()
    {
        transform.position = startPos;
        transform.localScale = originalScale;
    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        //originalScale = transform.localScale;
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