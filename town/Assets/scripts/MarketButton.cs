using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketButton : MonoBehaviour {

    private GameSystem gameSystem;
    private SoundManager soundManager;

    public void Awake()
    {
        gameSystem = GameObject.Find("GameSystems").GetComponent<GameSystem>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    public void MarketButtonDown()
    {
        soundManager.Play(soundManager.sound[0]);
        
        //market page
        gameSystem.marketPage.gameObject.SetActive(true);

        //Panel Hide
        gameSystem.sidePanelLeft.SetActive(false);
        gameSystem.sidePanelRight.SetActive(false);




    }
}
