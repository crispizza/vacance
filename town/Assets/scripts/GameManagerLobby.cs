using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLobby : MonoBehaviour {

    private static GameManagerLobby gameManagerLobby;

    public static GameManagerLobby GetGameManager()
    {
        if(gameManagerLobby == null)
        {
            gameManagerLobby = FindObjectOfType<GameManagerLobby>();
            if (gameManagerLobby == null)
            {
                GameObject container = new GameObject("Game Manager Clone");
                gameManagerLobby = container.GetComponent<GameManagerLobby>();
            }
        }
        return gameManagerLobby;
    }

    public GameObject rachelObj;
    public GameObject balloonObj;
    public GameObject textObj;
    public GameObject arrowObj;
    public GameObject MaskObj;
    public GameObject merrySnow;
    public GameObject skipButton;
    public GameObject tutorialArrow;


    private void Awake()
    {
        merrySnow.GetComponent<BoxCollider2D>().enabled = false;
        tutorialArrow.SetActive(false);
    }

    public void SkipButton()
    {
        skipButton.SetActive(false);
        rachelObj.SetActive(false);
        balloonObj.SetActive(false);
        textObj.SetActive(false);
        arrowObj.SetActive(false);
        MaskObj.SetActive(false);
        merrySnow.GetComponent<BoxCollider2D>().enabled = true;
        tutorialArrow.SetActive(true);

    }

    public void Fade()
    {
        skipButton.SetActive(false);
        rachelObj.GetComponent<Animator>().Play("Fade Out");
        balloonObj.GetComponent<Animator>().Play("Fade Out");
        textObj.GetComponent<Animator>().Play("Text Out");
        arrowObj.GetComponent<Animator>().Play("Fade Out");
        MaskObj.GetComponent<Animator>().Play("Mask Out");
        merrySnow.GetComponent<BoxCollider2D>().enabled = true;
        StartCoroutine(TutorialArrowAppear());
    }

    IEnumerator TutorialArrowAppear()
    {
        yield return new WaitForSeconds(1f);
        tutorialArrow.SetActive(true);
    }
}
