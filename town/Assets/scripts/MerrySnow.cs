using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MerrySnow : MonoBehaviour {


    private void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
    }

    private void OnMouseUp()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        SceneManager.LoadScene ("main");
        
    }


}
