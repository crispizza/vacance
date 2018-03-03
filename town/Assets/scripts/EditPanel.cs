using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPanel : MonoBehaviour {

    private GameSystem gameSystem;


    public void Awake()
    {
        gameSystem = GameObject.Find("GameSystems").GetComponent<GameSystem>();

    }

    public void FlipButton()
    {
        if(gameSystem.selectedItem.GetComponent<Item>().isFlipped == false)
        {
            gameSystem.selectedItem.transform.localScale = new Vector3(-1f, 1f, 1f);
            gameSystem.selectedItem.GetComponent<Item>().isFlipped = true;
        }
        else
        {
            gameSystem.selectedItem.transform.localScale = new Vector3(1f, 1f, 1f);
            gameSystem.selectedItem.GetComponent<Item>().isFlipped = false;
        }

    }

    public void CancelButton()
    {        
        gameSystem.editPanel.SetActive(false);
        gameSystem.selectedItem.SetActive(false);
        gameSystem.selectedItem = null;
        gameSystem.EditMode(false);

    }

    public void SetButton()
    {

        gameSystem.selectedItem.GetComponent<Item>().isPurchased = true;
        gameSystem.editPanel.SetActive(false);
        gameSystem.selectedItem = null;
        gameSystem.EditMode(false);
    }
}
