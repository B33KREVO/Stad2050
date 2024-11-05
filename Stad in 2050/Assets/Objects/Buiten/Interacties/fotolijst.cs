using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fotolijst : MonoBehaviour
{
    public Image afbeelding; // Vervang Text door Image

    void Start()
    {
        afbeelding.enabled = false; // Zorg ervoor dat de afbeelding onzichtbaar is bij start
    }

    public void Lezen()
    {
        afbeelding.enabled = true; // Toon de afbeelding
        StartCoroutine(AfbeeldingWeg());
    }

    IEnumerator AfbeeldingWeg()
    {
        yield return new WaitForSeconds(3); // Wacht 3 seconden
        afbeelding.enabled = false; // Verberg de afbeelding
    }
}