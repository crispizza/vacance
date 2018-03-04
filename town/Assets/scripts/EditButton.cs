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
        soundManager.Play(soundManager.sound[0]);

        if(gameSystem.gameState_editable == false)
        { 
            gameSystem.EditMode(true);
            gameSystem.readyToSelect = true;
            gameSystem.gameState_editMode = true;
            gameObject.GetComponent<Image>().sprite = sprite[1];
        }
        else
        {
            gameSystem.EditMode(false);
            gameSystem.readyToSelect = false;
            gameSystem.gameState_editMode = false;
            gameObject.GetComponent<Image>().sprite = sprite[0];
        }


    }
}
