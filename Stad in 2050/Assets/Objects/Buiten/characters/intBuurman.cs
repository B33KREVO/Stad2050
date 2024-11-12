using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intBuurman : MonoBehaviour
{
    public Text text;  // Make sure this is assigned in the Unity Editor
    public AudioClip HintFX;

    void Start()
    {
        text.enabled = false;  // Make sure the text is initially hidden
    }

    public void Read()
    {
        text.text = "Did you see the news, we're the next ones to be flooded!";
        text.enabled = true;
        StartCoroutine(TextFade());
    }

    IEnumerator TextFade()
    {
        yield return new WaitForSeconds(5);
        text.enabled = false;
    }
}
