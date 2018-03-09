using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour {

    public float perspectiveZoomSpeed = 0.00001f;
    public float orthoZoomSpeed = .0001f;

    private void Update()
    {
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudediff = prevTouchDeltaMag - touchDeltaMag;
            

            if(Camera.main.orthographic)
            {
                Camera.main.orthographicSize += deltaMagnitudediff * orthoZoomSpeed;
                Camera.main.orthographicSize = Mathf.Min(Mathf.Max(Camera.main.orthographicSize, 9f), 18f);
            }
            else
            {
                Camera.main.fieldOfView += deltaMagnitudediff * perspectiveZoomSpeed;
                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, .1f, 179.9f);
            }
        }
    }
}
