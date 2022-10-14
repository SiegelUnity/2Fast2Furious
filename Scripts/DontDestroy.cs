using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private GameObject bgAudioGO;
    //private AudioSource bgAudioS;

    private void Awake()
    {
        bgAudioGO = GameObject.Find("AudioBG");
        //bgAudioS = bgAudioGO.GetComponent<AudioSource>();
        DontDestroyOnLoad(bgAudioGO.gameObject);
    }
}
