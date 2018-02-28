using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public GameObject grid;
    public GameObject tile;

    void Awake()
    {
        Debug.Log(this.name);
    }

    

}
