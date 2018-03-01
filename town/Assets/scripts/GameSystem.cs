using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {

    public int gameState_editable = 0;
    public GameObject button_edit;
    public GameObject market;
    private SpriteRenderer gridSp;
    private SpriteRenderer[] tilesSp;
    private GameObject[] tiles;

    private void Awake()
    {
        gridSp = GameObject.FindGameObjectWithTag("grid").GetComponent<SpriteRenderer>();
        tiles = GameObject.FindGameObjectsWithTag("item");
        tilesSp = new SpriteRenderer[tiles.Length];
        for (int i = 0; i < tiles.Length; i++)
            tilesSp[i] = tiles[i].GetComponent<SpriteRenderer>();

        if (gridSp.enabled == true)
            gridSp.enabled = false;

        for (int i = 0; i < tiles.Length; i++)
            tilesSp[i].enabled = false;

        gameState_editable = 0;
        market.gameObject.SetActive(false);


    }

    public void EditButton()
    {
        if (gameState_editable == 0)
        {
            Debug.Log("editable");
            gameState_editable = 1;
            market.gameObject.SetActive(true);

            button_edit.GetComponent<Image>().color = Color.yellow;
            gridSp.enabled = true;

            for (int i = 0; i < tiles.Length; i++)
                tilesSp[i].enabled = true;

        }
        else if (gameState_editable == 1)
        {
            gameState_editable = 0;
            button_edit.GetComponent<Image>().color = Color.white;
            Debug.Log("noneditable");
            gridSp.enabled = false;

            market.gameObject.SetActive(false);

            for (int i = 0; i < tiles.Length; i++)
                tilesSp[i].enabled = false;

        }
    }
}
