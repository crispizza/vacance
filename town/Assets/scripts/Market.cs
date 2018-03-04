using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour {

    private GameSystem gameSystem;
    private GameObject SelectedItem;

    private SoundManager soundManager;

    public void Awake()
    {
        gameSystem = GameObject.Find("GameSystems").GetComponent<GameSystem>();

        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();

    }

    public void Purchase(GameObject item)
    {
        if (item.GetComponent<Item>().isPurchased == false)
        {
            //SOUND
            soundManager.Play(soundManager.sound[0]);

            //BUILD MODE
            gameSystem.gameState_buildMode = true;

            item.transform.position = new Vector2(12f, 5f);        
            gameSystem.selectedItem = item;
            item.gameObject.SetActive(true);

            gameSystem.editPanel.transform.position = new Vector2(12f, 5f);
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
        //Sound
        soundManager.Play(soundManager.sound[0]);

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
