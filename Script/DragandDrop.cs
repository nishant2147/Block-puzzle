using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragandDrop : MonoBehaviour
{
    //private Transform bigblock;
    BlockPiece pressBlock;

    void Start()
    {
        //bigblock = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Block")
                {
                    pressBlock = hit.collider.gameObject.GetComponent<BlockPiece>();

                    if (pressBlock.blockPlaced)
                    {
                        pressBlock = null;
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (pressBlock != null)
            {
                if (Grid.instance.inRange(pressBlock.transform.position))
                {
                    print("In Range...");

                    if (Grid.instance.isEmpty(pressBlock))
                    {
                        Grid.instance.placeBlock(pressBlock);
                        //Grid.instance.placeBlock2(pressBlock);

                        pressBlock = null;
                        return;
                    }
                }
                pressBlock.moveToOrignalPosition();
            }
            pressBlock = null;
        }

        if (Input.GetMouseButton(0))
        {
            if (pressBlock != null)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                pressBlock.transform.position = mousePos;
            }
        }
    }

    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            //Vector2 scaleUp = new Vector2(bigblock.localScale.x + 1f, bigblock.localScale.y + 1f);
            bigblock.localScale = scaleUp;

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                //Debug.Log(hit.collider.gameObject.name);
                pressBlock = hit.collider.gameObject;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            pressBlock = null;
        }

        if (Input.GetMouseButton(0))
        {
            if (pressBlock != null)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pressBlock.transform.position = new Vector3(
                mousePos.x,
                   mousePos.y,
                   pressBlock.transform.position.z
                   );
            }
        }

    }*/
}
