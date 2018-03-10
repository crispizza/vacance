using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastConstructionQuest : MonoBehaviour {

    public Item selectedItem = null;

    public void Yes()
    {
        if (GameSystem.GetGameSystem().tutorial.GetComponent<Tutorial>().isOn == true)
        {
            GameSystem.GetGameSystem().tutorial.GetComponent<Tutorial>().fastConst = true;
        }
        selectedItem.spriteRenderer.sprite = selectedItem.sprite;
        selectedItem.isUnderConstruction = false;
        selectedItem = null;
        this.gameObject.SetActive(false);
    }

    public void No()
    {
        if (GameSystem.GetGameSystem().tutorial.GetComponent<Tutorial>().isOn == true)
        {
            SoundManager.GetSoundManager().Play(SoundManager.GetSoundManager().sound[3]);
            return;
        }

        selectedItem = null;
        this.gameObject.SetActive(false);
    }

}
