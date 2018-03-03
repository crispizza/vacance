using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {

    public int gameState_editable = 0;
    public GameObject button_edit;
    public GameObject marketPage;
    public GameObject editPanel;
    public GameObject sidePanelLeft;
    public GameObject sidePanelRight;
    public SpriteRenderer gridSp;
    public SpriteRenderer[] tilesSp;
    public GameObject[] tiles;

    public GameObject selectedItem;

    private void Awake()
    {
        gridSp = GameObject.FindGameObjectWithTag("grid").GetComponent<SpriteRenderer>();

        tiles = GameObject.FindGameObjectsWithTag("item");
        tilesSp = new SpriteRenderer[tiles.Length];
        for (int i = 0; i < tiles.Length; i++)
        {
            tilesSp[i] = tiles[i].GetComponent<SpriteRenderer>();
            tilesSp[i].enabled = false;
        }

        if (gridSp.enabled == true)
            gridSp.enabled = false;
        

        gameState_editable = 0;
        marketPage.gameObject.SetActive(false);


    }


    public void EditMode(bool flag)
    {
        if (flag == true)
        {
            sidePanelLeft.SetActive(false);
            sidePanelRight.SetActive(false);

            gameState_editable = 1;
            
            gridSp.enabled = true;

            tiles = GameObject.FindGameObjectsWithTag("item");
            tilesSp = new SpriteRenderer[tiles.Length];
            for (int i = 0; i < tiles.Length; i++)
            {
                tilesSp[i] = tiles[i].GetComponent<SpriteRenderer>();
                tilesSp[i].enabled = true;
            }
        }

        if (flag == false)
        {
            sidePanelLeft.SetActive(true);
            sidePanelRight.SetActive(true);

            gameState_editable = 0;

            gridSp.enabled = false;

            tiles = GameObject.FindGameObjectsWithTag("item");
            tilesSp = new SpriteRenderer[tiles.Length];
            for (int i = 0; i < tiles.Length; i++)
            {
                tilesSp[i] = tiles[i].GetComponent<SpriteRenderer>();
                tilesSp[i].enabled = false;
            }
        }
    }
}
