using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastConstructionQuest : MonoBehaviour {

    public Item selectedItem = null;
    private Animator anim;

    public void Yes()
    {
        if (GameSystem.GetGameSystem().tutorial.GetComponent<Tutorial>().isOn == true)
        {
            GameSystem.GetGameSystem().tutorial.GetComponent<Tutorial>().fastConst = true;
        }

        SoundManager.GetSoundManager().Play(SoundManager.GetSoundManager().sound[0]);
        SoundManager.GetSoundManager().Play(SoundManager.GetSoundManager().sound[2]);
        selectedItem.GetComponent<Item>().spriteRenderer.sprite = selectedItem.sprite;
        selectedItem.GetComponent<Item>().isUnderConstruction = false;
        selectedItem = null;
        this.gameObject.SetActive(false);

        GameSystem.GetGameSystem().selectedItem.GetComponent<Item>().isConstructed = true;
        GameSystem.GetGameSystem().selectedItem.GetComponent<Item>().isUnderConstruction = false;
        GameSystem.GetGameSystem().selectedItem.GetComponent<Item>().isPurchased = true;



    }

  public void No()
    {
        anim = GameSystem.GetGameSystem().fastConstructionQuestion.GetComponent<Animator>();
        StartCoroutine(CoNo(.3f));
    }


    IEnumerator CoNo(float delay)
    {
        anim.Play("Pop Fade In and Scale Up Reversed");
        yield return new WaitForSeconds(delay);
        
        selectedItem = null;
        this.gameObject.SetActive(false);

        yield return null;
    }

}
