using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    Vector2 xLimitation = new Vector2(6f, 14f);
    Vector2 yLimitation = new Vector2(-5f, 15f);


    public float dragSpeed;
    private Vector2 dragOrigin;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector2 pos = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - dragOrigin);
        Vector2 move = new Vector2(pos.x * dragSpeed, pos.y * dragSpeed);
        
        
        
        transform.Translate(move, Space.World);

        




    }

}
