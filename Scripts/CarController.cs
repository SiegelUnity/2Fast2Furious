using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject streetEngineGO;
    public StreetEngine streetEngineScript;
    public GameObject carGO;
    public float turnAngle;
    public float speed;
    float turnInZ;

    void Start()
    {
        streetEngineGO = GameObject.Find("StreetEngine");
        streetEngineScript = streetEngineGO.GetComponent<StreetEngine>();
        carGO = GameObject.FindObjectOfType<Car>().gameObject;
        turnAngle = -45;
        speed = 25;
    }

    void FixedUpdate()
    {
        if (streetEngineScript.gameStart)
        {
            turnInZ = 0;
            transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
            turnInZ = Input.GetAxis("Horizontal") * turnAngle;

            carGO.transform.rotation = Quaternion.Euler(0, 0, turnInZ);
        }
    }
}
