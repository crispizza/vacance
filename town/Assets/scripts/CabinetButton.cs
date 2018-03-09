using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetButton : MonoBehaviour {

    public void CabinetButtonDown()
    {
        SoundManager.GetSoundManager().Play(SoundManager.GetSoundManager().sound[0]);

        //market page
        GameSystem.GetGameSystem().cabinet.gameObject.SetActive(true);

        //Panel Hide
        GameSystem.GetGameSystem().sidePanelLeft.SetActive(false);
        GameSystem.GetGameSystem().sidePanelRight.SetActive(false);
        GameSystem.GetGameSystem().bottomLeft.SetActive(false);
        GameSystem.GetGameSystem().bottomRight.SetActive(false);




    }
}
