using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour {

    private static BGMManager instance = null;
    public static BGMManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance !=null && instance !=this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
