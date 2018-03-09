using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastConstructionQuest : MonoBehaviour {

    public Item selectedItem = null;

    public void Yes()
    {
        selectedItem.spriteRenderer.sprite = selectedItem.sprite;
        selectedItem.isUnderConstruction = false;
        selectedItem = null;
        this.gameObject.SetActive(false);
    }

    public void No()
    {
        selectedItem = null;
        this.gameObject.SetActive(false);
    }

}
