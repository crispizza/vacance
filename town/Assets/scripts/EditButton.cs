using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditButton : MonoBehaviour {

    private GameSystem gameSystem;
    private SoundManager soundManager;
    public Sprite[] sprite;

    public void Awake()
    {
        gameSystem = GameObject.Find("GameSystems").GetComponent<GameSystem>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    public void EditButtonDown()
    {
        if (gameSystem.gameState_editable == false)
        {
            soundManager.Play(soundManager.sound[0]);
            gameSystem.EditMode(true);
            gameSystem.bottomRight.SetActive(true);
            gameSystem.readyToSelect = true;
            gameSystem.gameState_editMode = true;
            gameObject.GetComponent<Image>().sprite = sprite[1];
        }
        else
        {
            if(gameSystem.selectedItem == null)
            {
                soundManager.Play(soundManager.sound[0]);
                gameSystem.EditMode(false);
                gameSystem.readyToSelect = false;
                gameSystem.gameState_editMode = false;
                gameObject.GetComponent<Image>().sprite = sprite[0];
            }
        }
        //gameSystem.Save();

    }
}
