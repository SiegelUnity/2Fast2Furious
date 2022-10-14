using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetEngine : MonoBehaviour
{
    public float speed;
    public float streetSize;

    public bool gameStart;
    public bool screenOut;

    public GameObject streetContainerGO;
    public GameObject[] streetContainerArray;
    public GameObject beforeStreet;
    public GameObject afterStreet;
    public GameObject mainCamGO;
    public Camera mainCamComp;

    int streetCount = 0;
    int streetSelector;

    public Vector3 screenLimit;

    public GameObject carGO;
    public GameObject audioFXGO;
    public AudioFX audioFXScript;
    public GameObject endBGGO;

    void Start()
    {
        startGame();
    }

    void startGame()
    {
        streetContainerGO = GameObject.Find("StreetContainer");
        mainCamGO = GameObject.Find("Main Camera");
        mainCamComp = mainCamGO.GetComponent<Camera>();

        endBGGO = GameObject.Find("PanelGameOver");
        endBGGO.SetActive(false);

        audioFXGO = GameObject.Find("AudioFX");
        audioFXScript = audioFXGO.GetComponent<AudioFX>();

        carGO = GameObject.Find("Car");

        motorSpeed();
        measureScreen();
        findStreet();
    }

    public void EndGame()
    {
        carGO.GetComponent<AudioSource>().Stop();
        audioFXScript.FXMusic();
        endBGGO.SetActive(true);
    }

    void motorSpeed()
    {
        speed = 10;
    }

    void findStreet()
    {
        streetContainerArray = GameObject.FindGameObjectsWithTag("Street");
        for (int i = 0; i < streetContainerArray.Length; i++)
        {
            streetContainerArray[i].gameObject.transform.parent = streetContainerGO.transform;
            streetContainerArray[i].gameObject.SetActive(false);
            streetContainerArray[i].gameObject.name = "StreetOFF_" + i;
        }
        createStreet();
    }
    void createStreet()
    {
        streetCount++;
        streetSelector = Random.Range(0, streetContainerArray.Length);
        GameObject street = Instantiate(streetContainerArray[streetSelector]);
        street.SetActive(true);
        street.name = "Street_" + streetCount;
        street.transform.parent = gameObject.transform;
        streetPosition();
    }

    void streetPosition()
    {
        beforeStreet = GameObject.Find("Street_" + (streetCount - 1));
        afterStreet = GameObject.Find("Street_" + streetCount);
        streetLength();
        afterStreet.transform.position = new Vector3(beforeStreet.transform.position.x, beforeStreet.transform.position.y + streetSize-0.5f, 0);
        screenOut = false;
    }

    void streetLength()
    {
        for (int i = 0; i < beforeStreet.transform.childCount; i++)
        {
            if (beforeStreet.transform.GetChild(i).gameObject.GetComponent<Piece>() != null)
            {
                float pieceSize = beforeStreet.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                streetSize = streetSize + pieceSize;
            }
        }
    }

    void measureScreen()
    {
        screenLimit = new Vector3(0, mainCamComp.ScreenToWorldPoint(new Vector3(0,0,0)).y - 0.5f, 0);
    }

    void destroyStreet()
    {
        Destroy(beforeStreet);
        streetSize = 0;
        beforeStreet = null;
        createStreet();
    }
    void Update()
    {
        if (gameStart)
        {
            speed += (Time.deltaTime * 0.1f);
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (beforeStreet.transform.position.y + streetSize < screenLimit.y && !screenOut)
            {
                screenOut = true;
                destroyStreet();
            }
        }
    }
}
