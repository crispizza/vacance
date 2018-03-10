using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPanel : MonoBehaviour {

    private GameSystem gameSystem;
    private SoundManager soundManager;


    public void Awake()
    {
        gameSystem = GameObject.Find("GameSystems").GetComponent<GameSystem>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();


    }

    public void FlipButton()
    {
        soundManager.Play(soundManager.sound[0]);

        if (gameSystem.selectedItem.GetComponent<Item>().isFlipped == false)
        {
            gameSystem.selectedItem.transform.localScale = new Vector3(-1f, 1f, 1f);
            gameSystem.selectedItem.GetComponent<Item>().isFlipped = true;
        }
        else
        {
            gameSystem.selectedItem.transform.localScale = new Vector3(1f, 1f, 1f);
            gameSystem.selectedItem.GetComponent<Item>().isFlipped = false;
        }
        
        //gameSystem.Save();

    }

    public void SetButton()
    {

       
        if (gameSystem.selectedItem.GetComponent<Item>().isSetable == true)
        { 
            //BUILD MODE
            if (gameSystem.gameState_buildMode == true)
            {
                if (GameSystem.GetGameSystem().tutorial.GetComponent<Tutorial>().isOn)
                {
                    if (gameSystem.selectedItem.name == "hotel" || gameSystem.selectedItem.name == "Hotel")
                    {
                        gameSystem.tutorial.GetComponent<Tutorial>().monkeyHotelSet = true;
                    }

                    if (gameSystem.selectedItem.name == "cafe" || gameSystem.selectedItem.name == "Cafe")
                    {
                        GameSystem.GetGameSystem().tutorial.GetComponent<Tutorial>().hotChocoCafe = true;
                    }

                }
                soundManager.Play(soundManager.sound[1]);
                soundManager.Play(soundManager.sound[0]);

                gameSystem.selectedItem.GetComponent<Item>().isPurchased = true;
                gameSystem.selectedItem.GetComponent<Item>().isUnderConstruction = true;
                gameSystem.selectedItem.GetComponent<Item>().spriteRenderer.sprite = gameSystem.constructionSprite;

                gameSystem.editPanel.SetActive(false);
                gameSystem.selectedItem = null;
                gameSystem.EditMode(false);
            
                gameSystem.gameState_buildMode = false;
            }

            //EDIT MODE
            if(gameSystem.gameState_editMode == true)
            {

                if (GameSystem.GetGameSystem().tutorial.GetComponent<Tutorial>().isOn)
                {
                    if (gameSystem.selectedItem.name == "cafe" || gameSystem.selectedItem.name == "Cafe")
                    {
                        GameSystem.GetGameSystem().tutorial.GetComponent<Tutorial>().hotChocoCafe = true;
                    }
                    
                }
                soundManager.Play(soundManager.sound[0]);
                gameSystem.editPanel.SetActive(false);
                gameSystem.selectedItem = null;
                gameSystem.readyToSelect = true;


            }
        }


        //gameSystem.Save();

    }

    public void CancelButton()
    {
        if (GameSystem.GetGameSystem().tutorial.GetComponent<Tutorial>().isOn == true)
        {
            SoundManager.GetSoundManager().Play(SoundManager.GetSoundManager().sound[3]);
            return;
        }



        if (gameSystem.gameState_buildMode == true)
        {
            soundManager.Play(soundManager.sound[0]);
            gameSystem.editPanel.SetActive(false);
            gameSystem.selectedItem.SetActive(false);
            gameSystem.selectedItem = null;
            gameSystem.EditMode(false);
            gameSystem.readyToSelect = true;
            
            gameSystem.gameState_buildMode = false;
        }

        if (gameSystem.gameState_editMode == true)
        {
            soundManager.Play(soundManager.sound[0]);
            gameSystem.selectedItem.transform.position = gameSystem.selectedItem.GetComponent<DragAndDrop>().basePos;
            gameSystem.editPanel.SetActive(false);
            gameSystem.selectedItem = null;
            gameSystem.readyToSelect = true;            
        }


        //gameSystem.Save();

    }
}
