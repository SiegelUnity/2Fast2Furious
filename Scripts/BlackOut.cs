using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackOut : MonoBehaviour
{
    public Image blackOut;
    public string[] scenes;
    private void Start()
    {
        blackOut.CrossFadeAlpha(0, 2, false);  
    }

    public void FadeOut (int s)
    {
        blackOut.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine(changeScene(scenes[s]));
    }

    IEnumerator changeScene(string scene)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
