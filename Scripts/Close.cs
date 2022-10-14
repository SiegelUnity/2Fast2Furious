using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    public void closeGame()
    {
        Application.Quit();
        Debug.Log("Juego cerrado");
    }
}
