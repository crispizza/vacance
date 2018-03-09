using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private static SoundManager instance = null;
    public static SoundManager Instance
    {
        get { return instance; }
    }

    public static SoundManager GetSoundManager()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<SoundManager>();
            if (instance == null)
            {
                GameObject container = new GameObject("Game Manager Clone");
                instance = container.GetComponent<SoundManager>();
            }
        }
        return instance;
    }


    public AudioClip[] sound;
    public AudioSource audioSource;

    void Awake()
    {
        if (instance != null && instance != this)
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

    
    public void Play(AudioClip sound)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(sound);
        
    }


}
