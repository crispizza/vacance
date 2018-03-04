using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {

    public bool gameState_editMode;
    public bool gameState_buildMode;
    public bool gameState_editable;
    public GameObject button_edit;
    public GameObject marketPage;
    public GameObject editPanel;
    public GameObject sidePanelLeft;
    public GameObject sidePanelRight;
    public SpriteRenderer gridSp;
    public SpriteRenderer[] tilesSp;
    public GameObject[] tiles;

    public GameObject selectedItem;
    public bool readyToSelect;


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
        

        gameState_editable = false;
        marketPage.gameObject.SetActive(false);


    }


    public void EditMode(bool flag)
    {
        if (flag == true)
        {
            sidePanelLeft.SetActive(false);
            sidePanelRight.SetActive(false);

            gameState_editable = true;
            
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

            gameState_editable = false;
            editPanel.SetActive(false);

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
