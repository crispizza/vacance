using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour {

    public void SetItem(GameObject item)
    {
        if (item.GetComponent<Item>().isPurchased == true)
        {
            //SOUND
            SoundManager.GetSoundManager().Play(SoundManager.GetSoundManager().sound[0]);

            //BUILD MODE
            GameSystem.GetGameSystem().gameState_buildMode = true;

            item.transform.position = new Vector2(12f, 5f);
            GameSystem.GetGameSystem().selectedItem = item;
            item.gameObject.SetActive(true);

            GameSystem.GetGameSystem().editPanel.transform.position = new Vector2(12f, 5f);
            GameSystem.GetGameSystem().editPanel.SetActive(true);
            GameSystem.GetGameSystem().editPanel.transform.position = item.transform.position;

            GameSystem.GetGameSystem().cabinet.SetActive(false);

            //Edit Mode On
            GameSystem.GetGameSystem().EditMode(true);
        }
        else
        {
            Debug.Log("Already Purchased");
        }
    }

    public void CabinetExit()
    {
        //Sound
        SoundManager.GetSoundManager().Play(SoundManager.GetSoundManager().sound[0]);

        //selectedItem
        GameSystem.GetGameSystem().selectedItem = null;

        //market page
        GameSystem.GetGameSystem().cabinet.gameObject.SetActive(false);

        //Edit Panel set
        GameSystem.GetGameSystem().editPanel.SetActive(false);

        //Edit Mode off
        GameSystem.GetGameSystem().EditMode(false);
    }
}
