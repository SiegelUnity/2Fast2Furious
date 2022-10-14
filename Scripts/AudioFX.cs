using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public AudioClip[] fxs;
    AudioSource audioS;
    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    //0 Choque

    public void FXCrashSound()
    {
        audioS.clip = fxs[0];
        audioS.Play();
    }
    // 1 Bandolero

    public void FXMusic()
    {

    }

}
