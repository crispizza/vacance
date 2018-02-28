using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

    //GRID SIZE
    float size = 1f;

    Vector2 basePos;

    Vector2 dist;
    Vector2 worldPos;

    Vector2 alignedPos;
    float posX;
    float posY;

    private void Awake()
    {
        //Layer Order Sorting
        gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = (int)Mathf.Abs(gameObject.transform.position.y.Remap(0f, 10f, 10f, 0f));
    }


    private void OnMouseDown()
    {

        if (GameObject.Find("GameSystems").GetComponent<GameSystem>().gameState_editable == 1)
        {
            //Set Base Position
            basePos = gameObject.transform.position;

            //Get Mouse Position
            dist = Camera.main.WorldToScreenPoint(transform.position);
            posX = Input.mousePosition.x - dist.x;
            posY = Input.mousePosition.y - dist.y;
        }

    }

    private void OnMouseDrag()
    {
        if (GameObject.Find("GameSystems").GetComponent<GameSystem>().gameState_editable == 1)
        { 
            //Get Mouse Moving Position
            Vector2 curPos = new Vector2(Input.mousePosition.x - posX, Input.mousePosition.y - posY);

            //Set Mouse Position to World Position
            worldPos = Camera.main.ScreenToWorldPoint(curPos);

            //Set gameObject position and Snapping
            transform.position = Snap(worldPos);

            //Set Layer Order
            gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = (int)Mathf.Abs(gameObject.transform.position.y.Remap(0f, 10f, 10f, 0f));
        }

    }

    private void OnMouseUp()
    {
        if (GameObject.Find("GameSystems").GetComponent<GameSystem>().gameState_editable == 1)
        {
            
            //Set gameObject position and Snapping
            transform.position = Snap(worldPos); ;

            //If <<RED>> -> set to base pos
            SpriteRenderer[] childrenList = this.gameObject.GetComponentsInChildren<SpriteRenderer>();
            if (childrenList[1].color == Color.red)
                transform.position = basePos;
            

            //Set Layer Order
            gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = (int)Mathf.Abs(gameObject.transform.position.y.Remap(0f, 10f, 10f, 0f));
            
        }
        
    }


    public Vector2 Snap(Vector2 pos)
    {
        if (Mathf.Round(pos.y) %2 == 0 ) // even number -> 4*x + 2
        {
            pos.x -= 2;
            if (pos.x % 4 >= 2)
                pos.x = pos.x - (pos.x % 4) + 4;
            else
                pos.x = pos.x - (pos.x % 4);
            pos.x += 2;
        }
        else // odd number -> 4 * x
        {
            if (pos.x % 4 >= 2)
                pos.x = pos.x - (pos.x % 4) + 4;
            else
                pos.x = pos.x - (pos.x % 4);
        }

        return new Vector2 (pos.x, Mathf.Round(pos.y));
    }

}



public static class ExtensionMethods
{
    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
