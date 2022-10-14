using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public GameObject streetEngineGO;
    public StreetEngine streetEngineScript;
    public Sprite[] numbers;

    public GameObject numberCountGO;
    public SpriteRenderer numberCountComp;

    public GameObject carControllerGO;
    public GameObject carGO;
    void Start()
    {
        startComponents();
        startCountDown();
    }

    void startComponents()
    {
        streetEngineGO = GameObject.Find("StreetEngine");
        streetEngineScript = streetEngineGO.GetComponent<StreetEngine>();

        numberCountGO = GameObject.Find("NumberCount");
        numberCountComp = numberCountGO.GetComponent<SpriteRenderer>();
        carControllerGO = GameObject.Find("CarController");
        carGO = GameObject.Find("Car");

    }

    void startCountDown()
    {
        StartCoroutine(countRutine());
    }

    IEnumerator countRutine()
    {
        carControllerGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        numberCountComp.sprite = numbers[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds (1);

        numberCountComp.sprite = numbers[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        numberCountComp.sprite = numbers[3];
        streetEngineScript.gameStart = true;
        numberCountGO.GetComponent<AudioSource>().Play();
        carGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.64f);

        numberCountGO.SetActive(false);
    }
}
