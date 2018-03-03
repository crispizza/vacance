using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketButton : MonoBehaviour {

    private GameSystem gameSystem;

    public void Awake()
    {
        gameSystem = GameObject.Find("GameSystems").GetComponent<GameSystem>();
    }

    public void MarketButtonDown()
    {

        //market page
        gameSystem.marketPage.gameObject.SetActive(true);

        //Panel Hide
        gameSystem.sidePanelLeft.SetActive(false);
        gameSystem.sidePanelRight.SetActive(false);




    }
}
