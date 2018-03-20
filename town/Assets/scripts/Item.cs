using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public bool isPurchased;
    public bool isFlipped;
    public bool isSetable;
    public bool isUnderConstruction;
    public bool isConstructed;
    public Sprite sprite;
    

    private bool isReadyToEdit;
    private float count;

    public SpriteRenderer spriteRenderer;
  

    public void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnMouseUp()
    {
        if (isUnderConstruction == true)
        {
            if(SoundManager.GetSoundManager().audioSource.isPlaying == false)
                SoundManager.GetSoundManager().Play(SoundManager.GetSoundManager().sound[2]);
            GameSystem.GetGameSystem().fastConstructionQuestion.SetActive(true);
            GameSystem.GetGameSystem().fastConstructionQuestion.GetComponent<FastConstructionQuest>().selectedItem = this;


        }

        if (GameSystem.GetGameSystem().tutorial.GetComponent<Tutorial>().tutorial_mark6_hotelSelected == false && GameSystem.GetGameSystem().tutorial.GetComponent<Tutorial>().monkeyHotelSet == true)
            GameSystem.GetGameSystem().tutorial.GetComponent<Tutorial>().tutorial_mark6_hotelSelected = true;

    }

    public void OnMouseDown()
    {
        isReadyToEdit = true;
        count = 0;
    }

    public void OnMouseExit()
    {
        isReadyToEdit = false;
        count = 0;
    }

    public void Update()
    {
        if (isReadyToEdit == true)
        {
            count += Time.deltaTime;
            if(count > 1f && GameSystem.GetGameSystem().gameState_editable == false)//
            {
                GameSystem.GetGameSystem().editButton.GetComponent<EditButton>().EditButtonDown();
                count = 0;
            }
        }
    }

}
