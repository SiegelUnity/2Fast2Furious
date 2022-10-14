using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chrono : MonoBehaviour
{
    public GameObject streetEngineGO;
    public StreetEngine streetEngineScript;

    public float time;
    public float distance;

    public TextMeshProUGUI txtTime;
    public TextMeshProUGUI txtDistance;
    public TextMeshProUGUI txtEndDistance;

    void Start()
    {
        streetEngineGO = GameObject.Find("StreetEngine");
        streetEngineScript = streetEngineGO.GetComponent<StreetEngine>();

        txtTime.text = "02:00";
        txtDistance.text = "0";

        time = 120;
    }
    void Update()
    {
        if (streetEngineScript.gameStart)
        {
            calculateTimeDistance();
        }
        
        if (streetEngineScript.gameStart)
        {
            txtEndDistance.text = ((int)distance).ToString() + " M";
        }
        /*
        if (time < 1 && streetEngineScript.gameStart)
        {
            streetEngineScript.gameStart = false;
            streetEngineScript.EndGame();
            txtEndDistance.text = ((int) distance).ToString() + " M";
        }
        */
    }

    void calculateTimeDistance()
    {
        distance += Time.deltaTime * streetEngineScript.speed;
        txtDistance.text = ((int)distance).ToString();
        time -= Time.deltaTime;
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;

        txtTime.text = minutes.ToString().PadLeft(2,'0') + ":" + seconds.ToString().PadLeft(2,'0');
    }
}
