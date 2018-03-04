using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditButton : MonoBehaviour {

    private GameSystem gameSystem;
    private SoundManager soundManager;

    public void Awake()
    {
        gameSystem = GameObject.Find("GameSystems").GetComponent<GameSystem>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    public void EditButtonDown()
    {
        soundManager.Play(soundManager.sound[0]);

        if(gameSystem.gameState_editable == 0)
            gameSystem.EditMode(true);
        else
            gameSystem.EditMode(false);

    }
}
