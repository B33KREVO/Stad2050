using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intBuurman : MonoBehaviour
{
    public Text text;  // Text component to show the message

    void Start()
    {
        text.enabled = false;  // Make sure the text is initially hidden
        Read();  // Automatically show the text when the game starts
    }

    public void Read()
    {
        text.text = "Did you see the news, we're the next ones to be flooded!";
        text.enabled = true;
        StartCoroutine(TextFade());
    }

    IEnumerator TextFade()
    {
        yield return new WaitForSeconds(5);  // Wait for 5 seconds
        text.enabled = false;  // Hide the text after 5 seconds
    }
}
