using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFinish : MonoBehaviour {

    private Animator anim;
    public bool isClosed = false;

    public void close()
    {
        anim = GameSystem.GetGameSystem().tutorialFinish.GetComponent<Animator>();

        StartCoroutine(CloseCo(1f));

        GameSystem.GetGameSystem().tutorial.GetComponent<Tutorial>().tutorialFinishClosed = true;

        this.gameObject.SetActive(false);
    }

    IEnumerator CloseCo(float delay)
    {

        anim.Play("Tutorial Finish Fade In and Scale Up Reversed");
        yield return new WaitForSeconds(delay);


        yield return null;

    }
    

}
