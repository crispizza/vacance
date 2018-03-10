using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform left;
    public Transform right;
    public Transform bottom;
    public Transform top;

    private float dragSpeed = 20f;
    private Vector2 dragOrigin;


    void Update()
    {
        if(GameSystem.GetGameSystem().cameraMovable == true)
        { 
            if(GameSystem.GetGameSystem().selectedItem == null)
            { 
                if (Input.GetMouseButtonDown(0))
                {
                    dragOrigin = Input.mousePosition;
                    return;
                }

                if (!Input.GetMouseButton(0)) return;

                Vector2 pos = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - dragOrigin);
                Vector2 move = new Vector2(-1 * pos.x * dragSpeed, -1 * pos.y * dragSpeed);
        

           
                if (move.x < 0) 
                {
                    if (left.position.x < -25f)
                        move.x = 0f;
                }

                if (move.x > 0)
                {
                    if (right.position.x > 45f) 
                        move.x = 0f;
                }
    
                if (move.y < 0)
                {
                    if (bottom.position.y < -22f)
                        move.y = 0;
                }

                if (move.y > 0)
                {
                    if (top.position.y > 32f)
                        move.y = 0;
                }

        
        
                transform.Translate(move, Space.World);
            }
        }
    }
}
