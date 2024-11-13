using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Als je TextMeshPro gebruikt voor de UI tekst

public class buurman : MonoBehaviour
{
    public string missietekst;  // Deze tekst willen we veranderen
    public TextMeshProUGUI missionText;
    public GameObject Buurman;
    public string buurmantekst;  // Deze tekst willen we veranderen
    public TextMeshProUGUI burmantext;

    void Start()
    {
        Buurman.SetActive(false);
    }

    // Update is called once per frame
    public void praten() {
        missietekst = "Go home to watch the news!";
        missionText.text = missietekst;  // Verander de tekst van de UI
        buurmantekst = "Have you heard? It is all over the news, we are about to be flooded!";
        burmantext.text = buurmantekst;  // Verander de tekst van de UI
        Buurman.SetActive(true);
        StartCoroutine(WachtEnVerwijder());
    }
        IEnumerator WachtEnVerwijder()
    {
        // Wacht 5 seconden
        yield return new WaitForSeconds(5f);

        // Verwijder het object (zelfs als het dit script is)
        Buurman.SetActive(false);
        buurmantekst = " ";
        burmantext.text = buurmantekst;  // Verander de tekst van de UI
}
}
