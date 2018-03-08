using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {
    
    private GameSystem gameSystem;
    private Transform editPanelTrans;

    public Vector2 basePos;

    Vector2 dist;
    Vector2 worldPos;

    Vector2 alignedPos;
    float posX;
    float posY;
    public void Awake()
    {
        //GAME SYSTEM
        gameSystem = GameObject.Find("GameSystems").GetComponent<GameSystem>();

        //EDIT PANEL TRANSFORM
        editPanelTrans = gameSystem.editPanel.GetComponent<Transform>();

        //Layer Order Sorting
        gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = (int)Mathf.Abs(gameObject.transform.position.y.Remap(-4, 20f, 13f, 0f));
        
        basePos = gameObject.transform.position;

     }


    private void OnMouseDown()
    {

        if(gameSystem.readyToSelect == true && gameSystem.gameState_editable == true)
        {
            gameSystem.selectedItem = gameObject;
            gameSystem.readyToSelect = false;
            gameSystem.editPanel.SetActive(true);
            gameSystem.editPanel.transform.position = gameSystem.selectedItem.transform.position;
        }

        if (gameSystem.selectedItem == gameObject)
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
        if (gameSystem.selectedItem == gameObject && gameSystem.gameState_editable == true)
        { 
            //Get Mouse Moving Position
            Vector2 curPos = new Vector2(Input.mousePosition.x - posX, Input.mousePosition.y - posY);

            //Set Mouse Position to World Position
            worldPos = Camera.main.ScreenToWorldPoint(curPos);

            //Set gameObject position and Snapping
            transform.position = Snap(worldPos);
            editPanelTrans.position = Snap(worldPos);

            //Set Layer Order
            gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = (int)Mathf.Abs(gameObject.transform.position.y.Remap(-4, 20f, 13f, 0f));
        }

    }

    private void OnMouseUp()
    {
        if (gameSystem.selectedItem == gameObject && gameSystem.gameState_editable == true)
        {
            
            //Set gameObject position and Snapping
            transform.position = Snap(worldPos); 
            editPanelTrans.position = Snap(worldPos);

            //If <<RED>> -> set to base pos
            SpriteRenderer[] childrenList = this.gameObject.GetComponentsInChildren<SpriteRenderer>();
            if (childrenList[1].color == Color.red)
            { 
                transform.position = basePos;
                editPanelTrans.position = basePos;
            }

            //Set Layer Order
            gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = (int)Mathf.Abs(gameObject.transform.position.y.Remap(-4, 20f, 13f, 0f));
            
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
