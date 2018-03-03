using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour {

    private GameSystem gameSystem;
    private GameObject SelectedItem;

    public void Awake()
    {
        gameSystem = GameObject.Find("GameSystems").GetComponent<GameSystem>();

    }

    public void Purchase(GameObject item)
    {
        if(item.GetComponent<Item>().isPurchased == false)
        {
        item.transform.position = new Vector2(12f, 5f);
        gameSystem.editPanel.transform.position = new Vector2(12f, 5f);
        gameSystem.selectedItem = item;
        item.gameObject.SetActive(true);
        gameSystem.editPanel.SetActive(true);
        gameSystem.editPanel.transform.position = item.transform.position;
        gameSystem.marketPage.SetActive(false);

        //Edit Mode On
        gameSystem.EditMode(true);
        }
        else
        {
            Debug.Log("Already Purchased");
        }
    }

    public void MarketExit()
    {
        //selectedItem
        gameSystem.selectedItem = null;

        //market page
        gameSystem.marketPage.gameObject.SetActive(false);

        //Edit Panel set
        gameSystem.editPanel.SetActive(false);

        //Edit Mode off
        gameSystem.EditMode(false);
    }
}
