using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public bool isPurchased;
    public bool isFlipped;
    public bool isSetable;
    public bool isUnderConstruction;
    public Sprite sprite;

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

    }

}
