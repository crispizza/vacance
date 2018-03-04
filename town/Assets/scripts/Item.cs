using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public bool isPurchased;
    //public bool isSelected;
    public bool isFlipped;
    public bool isSetable;

    void Awake()
    {
        Debug.Log(this.name);
    }

    

}
