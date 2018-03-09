using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueManager : MonoBehaviour {

    private void OnMouseUp()
    {
        SceneManager.LoadScene("lobby");
    }
}
