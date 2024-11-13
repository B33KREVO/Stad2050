using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class trap : MonoBehaviour
{
    public Speler speler; // Ensure this is assigned in the Inspector
    public TMP_Text text;     // Ensure this is assigned in the Inspector

    void Start()
    {
        if (speler == null)
        {
            Debug.LogError("Speler reference is missing!");
        }

        if (text == null)
        {
            Debug.LogError("Text reference is missing!");
        }
    }

    public void naarBoven()
    {
        if (speler == null || text == null)
        {
            Debug.LogError("Required references are missing!");
            return;
        }

        if (speler.hasKey == false)
        {
            text.text = "You need items to go upstairs";
            text.enabled = true;
            StartCoroutine(TextFade());
        }
        else
        {
            text.text = "Going upstairs...";
            text.enabled = true;
            StartCoroutine(TextFade());
            SceneManager.LoadScene("Boven", LoadSceneMode.Single);
        }
    }

    IEnumerator TextFade()
    {
        yield return new WaitForSeconds(3);
        text.enabled = false;
    }
}
