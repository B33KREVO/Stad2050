using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Als je TextMeshPro gebruikt voor de UI tekst

public class buurman : MonoBehaviour
{
    public string missietekst;  // Deze tekst willen we veranderen
    public TextMeshProUGUI missionText;
    public GameObject missionBox;

    void Start()
    {
        missionBox.SetActive(true);
    }

    // Update is called once per frame
    public void praten() {
        missietekst = "Go home to watch the news!";
        missionText.text = missietekst;  // Verander de tekst van de UI
    }
}
