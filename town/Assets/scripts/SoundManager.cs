using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip[] sound;
    
    public void Play(AudioClip sound)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(sound);
        
    }


}
