using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerTitle : MonoBehaviour {
    
    public void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
        }

        if (Input.GetMouseButtonUp(0) == true)
        {
            SceneManager.LoadScene("lobby");
        }


    }

}
