using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Obstacle : MonoBehaviour
{
    public GameObject chronoGO;
    public Chrono chronoScript;
    public GameObject streetEngineGO;
    public StreetEngine streetEngineScript;
    public GameObject audioFXGO;
    public AudioFX audioFXScript;
    public TextMeshProUGUI txtEndDistance;

    private void Start()
    {
        chronoGO = GameObject.Find("Chrono");
        chronoScript = chronoGO.GetComponent<Chrono>();
        streetEngineGO = GameObject.Find("StreetEngine");
        streetEngineScript = streetEngineGO.GetComponent<StreetEngine>();
        audioFXGO = GameObject.Find("AudioFX");
        audioFXScript = audioFXGO.GetComponent<AudioFX>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Car>() != null)
        {
            audioFXScript.FXCrashSound();
            streetEngineScript.gameStart = false;
            streetEngineScript.EndGame();

            //chronoScript.time = 0;
        }
    }
}
