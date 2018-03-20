using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {
    private static GameSystem gameSystem;

    public static GameSystem GetGameSystem()
    {
        if (gameSystem == null)
        {
            gameSystem = FindObjectOfType<GameSystem>();
            if (gameSystem == null)
            {
                GameObject container = new GameObject("Game System Clone");
                gameSystem = container.GetComponent<GameSystem>();
            }
        }
        return gameSystem;
    }

    public bool gameState_editMode;
    public bool gameState_buildMode;
    public bool gameState_editable;
    public GameObject button_edit;
    public GameObject editButton;
    public GameObject marketPage;
    public GameObject cabinet;
    public GameObject editPanel;
    public GameObject sidePanelLeft;
    public GameObject sidePanelRight;
    public GameObject bottomLeft;
    public GameObject bottomRight;
    public SpriteRenderer gridSp;

    public SpriteRenderer[] tilesSp;
    public GameObject[] tiles;

    public GameObject selectedItem;
    public bool readyToSelect;

    public Sprite constructionSprite;
    public GameObject fastConstructionQuestion;

    public GameObject tutorial;

    public bool cameraMovable = true;

    public GameObject treeAndFlowers;
    public GameObject beds;
    public GameObject tutorialFinish;

    public GameObject hotel;




    private void Awake()
    {
        //LoadDefault();

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
        tutorial.SetActive(true);

    }
    

    public void EditMode(bool flag)
    {
        if (flag == true)
        {
            sidePanelLeft.SetActive(false);
            sidePanelRight.SetActive(false);
            bottomLeft.SetActive(false);
            bottomRight.SetActive(false);

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
            bottomLeft.SetActive(true);
            bottomRight.SetActive(true);

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

    /*
    public void Save()
    {
        GameObject[] list;
        list = GameObject.FindGameObjectsWithTag("Item");

        for(int i = 0; i < list.Length; i++)
        {
            Debug.Log("SAVE name:" +list[i].name + " x:" + list[i].transform.position.x + " y:" + list[i].transform.position.y + " pur:" + list[i].GetComponent<Item>().isPurchased.ToString() + " flip"+list[i].GetComponent<Item>().isFlipped.ToString());
            //Item.transform.position
            PlayerPrefs.SetFloat(list[i].name + "_posX", list[i].transform.position.x);
            PlayerPrefs.SetFloat(list[i].name + "_posY", list[i].transform.position.y);
            //Item.isPurchased
            PlayerPrefs.SetString(list[i].name + "_isPurchased", list[i].GetComponent<Item>().isPurchased.ToString());
            //Item.isFlipped
            PlayerPrefs.SetString(list[i].name + "_isFlipped", list[i].GetComponent<Item>().isFlipped.ToString());
        }



    }

    public void Load()
    {
        GameObject[] list;
        list = GameObject.FindGameObjectsWithTag("Item");

        for (int i = 0; i < list.Length; i++)
        {
            //Item.transform.position
            list[i].transform.position = new Vector2(PlayerPrefs.GetFloat(list[i].name + "_posX"), PlayerPrefs.GetFloat(list[i].name + "_posY"));
            //Item.isPurchased
            list[i].GetComponent<Item>().isPurchased = System.Convert.ToBoolean(PlayerPrefs.GetString(list[i].name + "_isPurchased"));
            
            //Item.isFlipped
            list[i].GetComponent<Item>().isFlipped = System.Convert.ToBoolean(PlayerPrefs.GetString(list[i].name + "_isFlipped"));
            Debug.Log("LOAD name:" + list[i].name + " x:" + list[i].transform.position.x + " y:" + list[i].transform.position.y + " pur:" + list[i].GetComponent<Item>().isPurchased.ToString() + " flip:" + list[i].GetComponent<Item>().isFlipped.ToString());
            if (list[i].GetComponent<Item>().isPurchased == false)
                list[i].transform.position = new Vector2(60f, 0f);

        }
    }
    
    public void LoadDefault()
    {
        GameObject[] list;
        list = GameObject.FindGameObjectsWithTag("Item");

        for (int i = 0; i < list.Length; i++)
        {
            //Item.transform.position
            if (list[i].name != "Office")
                list[i].transform.position = new Vector2(12f, 5f);
            else
                list[i].transform.position = new Vector2(26f, 4f);
            //Item.isPurchased
            if (list[i].name != "Office")
                list[i].GetComponent<Item>().isPurchased = false;
            else
                list[i].GetComponent<Item>().isPurchased = true;

            //Item.isFlipped
            list[i].GetComponent<Item>().isFlipped = false;

            if (list[i].GetComponent<Item>().isPurchased == false)
            {
                if (list[i].name != "Office")
                    list[i].transform.position = new Vector2(60f,0f);
            }
            Debug.Log("LOAD DEFAULT");
        }
    }
    */

}
